using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CredentialDao
    {
        ShopOnlineDbContext db = null;
        public CredentialDao()
        {
            db = new ShopOnlineDbContext();
        }
        public void Insert(string roleID, string userGrID)
        {
            var credential = new CREDENTIAL();
            credential.UserGroupID = userGrID;
            credential.RoleID = roleID;
            db.CREDENTIAL.Add(credential);
            db.SaveChanges();
        }

        public void Create(USERGROUP userGroup, string Role)
        {
            if (!string.IsNullOrEmpty(Role))
            {
                foreach (var role in Role.Split(','))
                {
                    this.Insert(role, userGroup.ID);
                }
            }
        }

        public void Update(USERGROUP userGroup, string Role)
        {
            this.RemoveAllCredential(userGroup.ID);
            if (!string.IsNullOrEmpty(Role))
            {
                foreach (var role in Role.Split(','))
                {
                    this.Insert(role, userGroup.ID);
                }
            }
        }

        public void RemoveAllCredential(string id)
        {
            db.CREDENTIAL.RemoveRange(db.CREDENTIAL.Where(x => x.UserGroupID == id));
            db.SaveChanges();
        }
    }
}
