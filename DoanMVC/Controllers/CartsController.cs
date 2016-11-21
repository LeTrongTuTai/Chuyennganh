using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoanMVC.Models;
using Model.DAO;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;
using Common;
using DoanMVC.Common;
using System.Security.Cryptography;
using System.Text;
using WebApplication2;

namespace DoanMVC.Controllers
{
    public class CartsController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Carts
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productId)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += 1;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult Cart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public ActionResult InFoCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            
            var order = new ORDER();
            order.CretedDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMobile = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.DAO.OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new ORDERDETAIL();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Areas/Client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn hàng mới từ Basic", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Basic", content);
            }
            catch (Exception)
            {
                //ghi log
                return Redirect("/loi-thanh-toan.html");
            }
            return Redirect("/hoan-thanh.html");
        }

        public ActionResult Success()
        {
            return View();
        }

        public JsonResult GetUser()
        {
            var model = (AccountLogin)Session[CommonConstants.AccountSession];
            if (model == null)
            {
                return Json(new
                {
                    status = false
                });
            }
            return Json(new
            {
                data = model,
                status = true
            });
        }
        [HttpPost]
        public JsonResult CreateOrder(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderDao = new OrderDao();
            var orderNew = new ORDER();
            orderNew.CretedDate = DateTime.Now;
            orderNew.ShipAddress = order.CustomerAddress;
            orderNew.ShipMobile = order.CustomerMobile;
            orderNew.ShipName = order.CustomerName;
            orderNew.ShipEmail = order.CustomerEmail;
            orderNew.CustomerMessage = order.CustomerMessage;
            orderNew.PaymentMethod = order.PaymentMethod;
            orderNew.PaymentStatus = order.PaymentStatus;
            orderNew.Status = true;
            orderDao.Insert(orderNew);
            var detailDao = new OrderDetailDao();
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            decimal total = 0;
            foreach (var item in sessionCart)
            {
                var detail = new ORDERDETAIL();
                detail.OrderID = orderNew.ID;
                detail.ProductID = item.Product.ID;
                detail.Quantity = item.Quantity;
                if (item.Product.PromotionPrice.HasValue)
                {
                    detail.Price = item.Product.PromotionPrice.Value;
                    total += (item.Product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
                }
                else
                {
                    detail.Price = item.Product.Price;
                    total += (item.Product.Price.Value * item.Quantity);
                }
                detailDao.Insert(detail);
            }
            
            

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Areas/Client/template/neworder.html"));
            content = content.Replace("{{CustomerName}}", order.CustomerName);
            content = content.Replace("{{Phone}}", order.CustomerMobile);
            content = content.Replace("{{Email}}", order.CustomerEmail);
            content = content.Replace("{{Address}}", order.CustomerAddress);
            content = content.Replace("{{Total}}", total.ToString("N0"));
            new MailHelper().SendMail(order.CustomerEmail, "Thông tin đơn đặt hàng từ T&Q", content);
            

            bool ax = true;
            if (Equals(orderNew.PaymentMethod, " Thanh toán trực tuyến"))
                ax = false;
            else
                Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = ax
            });
            
        }

        public ActionResult ThanhToanTT()
        {
            
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            var orderNew = new ORDER();
            decimal total = 0;
            foreach (var item in sessionCart)
            {
                var detail = new ORDERDETAIL();
                detail.OrderID = orderNew.ID;
                detail.ProductID = item.Product.ID;
                detail.Quantity = item.Quantity;
                if (item.Product.PromotionPrice.HasValue)
                {
                    detail.Price = item.Product.PromotionPrice.Value;
                    total += (item.Product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
                }
                else
                {
                    detail.Price = item.Product.Price;
                    total += (item.Product.Price.Value * item.Quantity);
                }
                
            }
            decimal totals = total * 100;
            var id = sessionCart.ToList().LastOrDefault();
            string text = "";
            foreach (var cart in sessionCart)
            {
                text = text + cart.Product.Name + "  " + cart.Product.Quantity;
                if (cart.Product.ID != id.Product.ID)
                {
                    text = text + " + ";
                }
            }

            Session[CommonConstants.CartSession] = null;


            string SECURE_SECRET = "A3EFDFABA8653DF2342E8DAC29B51AF0";
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan

            VPCRequest conn = new VPCRequest("https://mtf.onepay.vn/onecomm-pay/vpc.op");
            conn.SetSecureSecret(SECURE_SECRET);

            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", "ONEPAY");
            conn.AddDigitalOrderField("vpc_AccessCode", "D67342C2");
            conn.AddDigitalOrderField("vpc_MerchTxnRef", MaHoaMD5(ngaunhien().ToString()));
            conn.AddDigitalOrderField("vpc_OrderInfo", text);
            conn.AddDigitalOrderField("vpc_Amount", totals.ToString());
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", Url.Action("Index", "TrangChu", null, Request.Url.Scheme));
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", "");
            conn.AddDigitalOrderField("vpc_SHIP_City", "");
            conn.AddDigitalOrderField("vpc_SHIP_Country", "Vietnam");
            conn.AddDigitalOrderField("vpc_Customer_Phone","");
            conn.AddDigitalOrderField("vpc_Customer_Email", "");
            conn.AddDigitalOrderField("vpc_Customer_Id", "onepay_paygate");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", "");
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return Redirect(url);
        }

        private string MaHoaMD5(string input)
        {
            byte[] pass = Encoding.UTF8.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(pass);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }

        private int ngaunhien()
        {
            Random i = new Random();
            int i2;
            i2 = i.Next(-2147483648, 2147483647);
            return i2;
        }
    }
}