using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FeedbackDao
    {
        ShopOnlineDbContext db = null;
        public FeedbackDao()
        {
            db = new ShopOnlineDbContext();
        }

        public bool ChangeStatus(int id)
        {
            var user = db.FEEDBACK.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var feedback = db.FEEDBACK.Find(id);
                db.FEEDBACK.Remove(feedback);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public FEEDBACK GetById(int id)
        {
            return db.FEEDBACK.Find(id);
        }

        public List<FEEDBACK> ListAll()
        {
            return db.FEEDBACK.Where(x=>x.Status==true ||x.Status==false).OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public int Insert(FEEDBACK feedback)
        {
            try
            {
                db.FEEDBACK.Add(feedback);
                db.SaveChanges();
                return feedback.ID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}