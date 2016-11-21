using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AboutDao
    {
        ShopOnlineDbContext db = null;
        public AboutDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<ABOUT> about(int top)
        {
            return db.ABOUT.Where(x=>x.Status==true).OrderByDescending(x=>x.CreatedDate).Take(top).ToList();
        }
    }
}
