using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDetailDao
    {
        ShopOnlineDbContext db = null;
        public OrderDetailDao()
        {
            db = new ShopOnlineDbContext();
        }
        public bool Insert(ORDERDETAIL detail)
        {
            try
            {
                db.ORDERDETAIL.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
