using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Model.DAO
{
    public class CategoryDao
    {
        ShopOnlineDbContext db = null;
        public CategoryDao()
        {
            db = new ShopOnlineDbContext();
        }
        public long Insert(CATEGORY category)
        {
            db.CATEGORY.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public List<CATEGORY> ListAll()
        {
            return db.CATEGORY.Where(x => x.Status == true).ToList();
        }
        public CATEGORY ViewDetailCategory(long id)
        {
            return db.CATEGORY.SingleOrDefault(x=>x.ID==id);
        }

        public PRODUCT ViewDetail(long id)
        {
            return db.PRODUCT.SingleOrDefault(x => x.ID == id);
        }
        public IEnumerable<CATEGORY> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<CATEGORY> model = db.CATEGORY;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);

        }
        public bool Update(CATEGORY entity)
        {
            try
            {
                var category = db.CATEGORY.Find(entity.ID);
                category.Name = entity.Name;
                category.MetaTitle = entity.MetaTitle;
                category.ParentID = entity.ParentID;
                category.SeoTitle = entity.SeoTitle;
                category.DisplayOrder = entity.DisplayOrder;
                category.CreatedDate = entity.CreatedDate;
                category.CreateBy = entity.CreateBy;
                category.MetaKeywrds = entity.MetaKeywrds;
                category.MetaDescriptions = entity.MetaDescriptions;
                category.Language = entity.Language;
                category.ModefiedBy = entity.ModefiedBy;
                category.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public CATEGORY GetById(string Name)
        {
            return db.CATEGORY.SingleOrDefault(x => x.Name == Name);
        }

        public bool ChangeStatus(long id)
        {
            var category = db.CATEGORY.Find(id);
            category.Status = !category.Status;
            db.SaveChanges();
            return category.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.CATEGORY.Find(id);
                db.CATEGORY.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    
}
