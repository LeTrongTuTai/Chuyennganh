using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDao
    {
        ShopOnlineDbContext db = null;
        public OrderDao()
        {
            db = new ShopOnlineDbContext();
        }
        public long Insert(ORDER order)
        {
            db.ORDER.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public IEnumerable<ORDER> ListAll()
        {
            return db.ORDER;
        }
        public bool Delete(int id)
        {
            try
            {
                var Order = db.ORDER.Find(id);
                db.ORDER.Remove(Order);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ORDER GetById(int id)
        {
            return db.ORDER.Find(id);
        }
        public IEnumerable<ORDERDETAIL> GetOrderDetailByID(int id)
        {
            return db.ORDERDETAIL.Include("PRODUCT").Where(x => x.OrderID == id);
        }
        public bool ChangeStatus(int id)
        {
            var order = db.ORDER.Find(id);
            order.Status = !order.Status;
            db.SaveChanges();
            return order.Status;
        }
        public bool ChangeStatusPayment(int id)
        {
            var order = db.ORDER.Find(id);
            order.PaymentStatus = !order.PaymentStatus;
            db.SaveChanges();
            return order.PaymentStatus;
        }
    }
}
