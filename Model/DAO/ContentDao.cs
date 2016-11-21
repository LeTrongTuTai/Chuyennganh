using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
    public class ContentDao
    {
        ShopOnlineDbContext db = null;
        public ContentDao()
        {
            db = new ShopOnlineDbContext();
        }
        public CONTENT GetByID(long id)
        {
            return db.CONTENT.Find(id);
        }
        public List<CONTENT> newContent(int top)
        {
            return db.CONTENT.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public CONTENT ViewDetail(long id)
        {
            return db.CONTENT.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<CONTENT> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<CONTENT> model = db.CONTENT;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public long Insert(CONTENT entity)
        {
            db.CONTENT.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(CONTENT entity)
        {
            try
            {
                var content = db.CONTENT.Find(entity.ID);
                content.Name = entity.Name;
                content.Metatitle = entity.Metatitle;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.Detail = entity.Detail;
                content.CreatedDate = DateTime.Now;
                content.CreatedBy = entity.CreatedBy;
                content.ModifielDate = entity.ModifielDate;
                content.ModifielBy = entity.ModifielBy;
                content.MetaKeywords = entity.MetaKeywords;
                content.MetaDescriptions = entity.MetaDescriptions;
                content.Language = entity.Language;
                content.Status = entity.Status;
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
                var content = db.CONTENT.Find(id);
                db.CONTENT.Remove(content);
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
            var content = db.CONTENT.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
    }
}
