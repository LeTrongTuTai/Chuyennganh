using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideGroupDao
    {
        ShopOnlineDbContext db = null;
        public SlideGroupDao()
        {
            db = new ShopOnlineDbContext();
        }
        public IEnumerable<SLIDEGROUP> ListAll()
        {
            return db.SLIDEGROUP;
        }
    }
}
