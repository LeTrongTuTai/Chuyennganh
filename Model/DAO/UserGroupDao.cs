using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserGroupDao
    {
        ShopOnlineDbContext db = null;
        public UserGroupDao()
        {
            db = new ShopOnlineDbContext();
        }

        public IEnumerable<USERGROUP> ListAll()
        {
            return db.USERGROUP;
        }
        public IEnumerable<ROLE> ListAllRole()
        {
            return db.ROLE;
        }
        public IEnumerable<CREDENTIAL> GetCredentialByUserGroupID(string id)
        {
            return db.CREDENTIAL.Where(x => x.UserGroupID == id);
        }
        public IEnumerable<USERGROUP> GetAll()
        {
            return db.USERGROUP;
        }
        public USERGROUP ViewDetail(string id)
        {
            return db.USERGROUP.SingleOrDefault(x => x.ID == id);
        }

        public int Insert(USERGROUP entity)
        {
            if (db.USERGROUP.Any(x => x.Name == entity.Name))
                return -1;
            try
            {
                db.USERGROUP.Add(entity);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public int Update(USERGROUP entity)
        {
            if (db.USERGROUP.Any(x => x.Name == entity.Name && x.ID != entity.ID))
                return -1;
            var UserGroup = db.USERGROUP.Find(entity.ID);
            try
            {
                UserGroup.Name = entity.Name;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        public bool Delete(string id)
        {
            try
            {
                var UserGroup = db.USERGROUP.Find(id);
                db.USERGROUP.Remove(UserGroup);
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
