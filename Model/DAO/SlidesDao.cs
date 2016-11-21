using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class SlidesDao
    {
        ShopOnlineDbContext db = null;
        public SlidesDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<SLIDE> ListByGroupId(int groupID)
        {
            return db.SLIDE.Where(x => x.TypeID == groupID && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public bool ChangeStatus(int id)
        {
            var slide = db.SLIDE.Find(id);
            slide.Status = !slide.Status;
            db.SaveChanges();
            return slide.Status;
        }

        public IEnumerable<SLIDE> GetAll()
        {
            return db.SLIDE;
        }

        public IEnumerable<SLIDE> GetSlides()
        {
            return db.SLIDE.Where(x => x.Status == true).OrderByDescending(x => x.ID);
        }

        public SLIDE GetById(int id)
        {
            return db.SLIDE.Find(id);
        }

        public int Insert(SLIDE entity)
        {
            try
            {
                db.SLIDE.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool Update(SLIDE entity)
        {
            try
            {
                var Slide = db.SLIDE.Find(entity.ID);
                Slide.Image = entity.Image;
                Slide.DisplayOrder = entity.DisplayOrder;
                Slide.Link = entity.Link;
                Slide.Created_Date = DateTime.Now;
                Slide.Status = entity.Status;
                Slide.TypeID = entity.TypeID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var Slide = db.SLIDE.Find(id);
                db.SLIDE.Remove(Slide);
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
