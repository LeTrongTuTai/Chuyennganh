using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class MenuDao
    {
        ShopOnlineDbContext db = null;
        public MenuDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<MENU> ListByGroupId(int groupID)
        {
            return db.MENU.Where(x => x.TypeID == groupID && x.Status== true).OrderBy(x=>x.DisplayOrder).ToList();
        } 
    }
}
