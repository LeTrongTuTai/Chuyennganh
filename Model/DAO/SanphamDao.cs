using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class SanphamDao
    {
        ShopOnlineDbContext db = null;
        public SanphamDao()
        {
            db = new ShopOnlineDbContext();
        }
        public IEnumerable<PRODUCT> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PRODUCT> model = db.PRODUCT;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public long Insert(PRODUCT entity)
        {
            db.PRODUCT.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(PRODUCT entity)
        {
            try
            {
                var pro = db.PRODUCT.Find(entity.ID);
                pro.Name = entity.Name;
                pro.Metatitle = entity.Metatitle;
                pro.Description = entity.Description;
                pro.Price = entity.Price;
                pro.PromotionPrice = entity.Price;
                pro.Quantity = entity.Quantity;
                pro.ModifiedDate = entity.ModifiedDate;
                pro.Image = entity.Image;
                pro.MoreImages = entity.MoreImages;
                pro.Detail = entity.Detail;
                pro.CreatedDate = DateTime.Now;
                pro.MetaDescriptions = entity.MetaDescriptions;
                pro.MetaKeywords = entity.MetaKeywords;
                pro.CreatedBy = entity.CreatedBy;
                pro.ModifiedBy = entity.ModifiedBy;
                pro.Warranty = entity.Warranty;
                pro.TopHot = entity.TopHot;
                pro.Like = entity.Like;
                pro.ViewCount = entity.ViewCount;
                pro.Status = entity.Status ;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var pro = db.PRODUCT.Find(id);
                db.PRODUCT.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var pro = db.PRODUCT.Find(id);
            pro.Status = !pro.Status;
            db.SaveChanges();
            return pro.Status;
        }
        public PRODUCT GetByID(long id)
        {
            return db.PRODUCT.SingleOrDefault(x => x.ID == id);
        }
        public List<PRODUCT> ListAll()
        {
            return db.PRODUCT.Where(x => x.Status).ToList();
        }
        public void UpdateImages(int productId, string images)
        {
            var product = db.PRODUCT.Find(productId);
            product.MoreImages = images;
            db.SaveChanges();
        }
    }
}
