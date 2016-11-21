using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class LogoDao
    {
        ShopOnlineDbContext db = null;
        public LogoDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<LOGO>ListAll()
        {
            return db.LOGO.Where(x => x.Status == true).OrderByDescending(x => x.DisplayOrder).ToList();
        }

        public bool ChangeStatus(int id)
        {
            var logo = db.LOGO.Find(id);
            logo.Status = !logo.Status;
            db.SaveChanges();
            return logo.Status;
        }

        public IEnumerable<LOGO> GetAll()
        {
            return db.LOGO;
        }

        public IEnumerable<LOGO> GetSlides()
        {
            return db.LOGO.Where(x => x.Status == true).OrderByDescending(x => x.ID);
        }

        public LOGO GetById(int id)
        {
            return db.LOGO.Find(id);
        }

        public int Insert(LOGO entity)
        {
            try
            {
                db.LOGO.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool Update(LOGO entity)
        {
            try
            {
                var logo = db.LOGO.Find(entity.ID);
                logo.Logo = entity.Logo;
                logo.DisplayOrder = entity.DisplayOrder;
                logo.Link = entity.Link;
                logo.Created_Date = DateTime.Now;
                logo.Status = entity.Status;
                logo.Description = entity.Description;
                logo.Created_By = entity.Created_By;
                logo.Modified_By = entity.Modified_By;
                logo.Modified_Date = DateTime.Now;
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
                var Logo = db.LOGO.Find(id);
                db.LOGO.Remove(Logo);
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
