using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class ProductCategoryDao
    {
        ShopOnlineDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<PRODUCTCATEGORY> ListAll()
        {
            return db.PRODUCTCATEGORY.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        
    }
}
