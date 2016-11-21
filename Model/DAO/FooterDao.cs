using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class FooterDao
    {
        ShopOnlineDbContext db = null;
        public FooterDao()
        {
            db = new ShopOnlineDbContext();
        }
        public FOOTER GetFooter()
        {
            return db.FOOTER.SingleOrDefault(x => x.Status == true);
        }
    }
}
