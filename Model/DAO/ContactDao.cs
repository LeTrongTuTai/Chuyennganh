using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace Model.DAO
{
    public class ContactDao
    {
        ShopOnlineDbContext db = null;
        public ContactDao()
        {
            db = new ShopOnlineDbContext();
        }
        public CONTACT GetActiveContact()
        {
            return db.CONTACT.Single(x => x.Status == true);
        }
        public int InsertFeedBack(FEEDBACK fb)
        {
            db.FEEDBACK.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }


        public CONTACT GetContact()
        {
            return db.CONTACT.FirstOrDefault();
        }

        public CONTACT GetById(int id)
        {
            return db.CONTACT.SingleOrDefault(x => x.ID == id);
        }

        public bool Update(CONTACT entity)
        {
            try
            {
                var Contact = db.CONTACT.SingleOrDefault(x => x.ID == entity.ID);
                Contact.Content = entity.Content;
                Contact.Status = entity.Status;
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
            var pro = db.CONTACT.Find(id);
            pro.Status = !pro.Status;
            db.SaveChanges();
            return pro.Status;
        }
    }
}
