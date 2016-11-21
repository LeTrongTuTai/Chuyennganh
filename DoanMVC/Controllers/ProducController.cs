using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using PagedList;
using System.Runtime.InteropServices;


namespace DoanMVC.Controllers
{
    public class ProducController : Controller
    {
        // GET: Produc
        public ActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadDataAll(int page, int pageSize, string sort = "")
        {
            var model = new ProductDao().ListAll(sort);
            int totalRow = model.Count();
            model = model.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [ChildActionOnly]
        public ActionResult ProductMenu()
        {
            var model = new MenuDao().ListByGroupId(3);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult ProductHot()
        {
            var model = new ProductDao().TopHot(5);
            return PartialView(model);
        }

        [OutputCache(CacheProfile = "Cache1DayForProduct")]
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new CategoryDao().ViewDetail(product.ID);
            ViewBag.RelatedProduct = new ProductDao().ListRelatedProduct(id);
            new ProductDao().InsertView(id);
            new ProductDao().InsertLike(id);
            return View(product);
        }
        public ActionResult Category(long id)
        {
            var category = new CategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            //var model = new ProductDao().ListByCategoryId(id);
            return View(/*model*/);
        }
        public ActionResult ProductBanChay()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadDataAllBest(int page, int pageSize, string sort = "")
        {
            var model = new ProductDao().AllBuyBestProduct(sort);
            int totalRow = model.Count();
            model = model.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductMoi()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadDataAllMoi(int page, int pageSize, string sort = "")
        {
            var model = new ProductDao().ProductMoi(sort);
            int totalRow = model.Count();
            model = model.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductView()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadDataAllView(int page, int pageSize, string sort = "")
        {
            var model = new ProductDao().ProductView(sort);
            int totalRow = model.Count();
            model = model.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductSale()
        {                
            return View();
        }
        [HttpGet]
        public JsonResult LoadDataAllSale(int page, int pageSize, string sort = "")
        {
            var model = new ProductDao().ProductSale(sort);
            int totalRow = model.Count();
            model = model.Skip((page - 1) * pageSize).Take(pageSize);

            return Json(new
            {
                data = model,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
    }
}