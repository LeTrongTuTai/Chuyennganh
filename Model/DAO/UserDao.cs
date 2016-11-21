using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Configuration;
using Common;

namespace Model.DAO
{
    public class UserDao
    {
        ShopOnlineDbContext db = null;
        public UserDao()
        {
            db = new ShopOnlineDbContext();
        }

        public long Insert(USER entity)
        {
            db.USER.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<USER> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<USER> model = db.USER;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);

        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.USER.Single(x => x.UserName == userName);
            var data = (from a in db.CREDENTIAL
                        join b in db.USERGROUP on a.UserGroupID equals b.ID
                        join c in db.ROLE on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new CREDENTIAL()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }


        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.USER.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstant.ADMIN_GROUP || result.GroupID == CommonConstant.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }
        }

        public bool Update(USER entity)
        {
            try
            {
                var user = db.USER.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Phone = entity.Phone;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.GroupID = entity.GroupID;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //logging
                return false;
            }

        }
        public USER GetById(string userName)
        {
            return db.USER.SingleOrDefault(x => x.UserName == userName);
        }
        public USER ViewDetail(int id)
        {
            return db.USER.Find(id);
        }

        public bool ChangeStatus(long id)
        {
            var user = db.USER.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.USER.Find(id);
                db.USER.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            public bool CheckUserName(string userName)
        {
            return db.USER.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.USER.Count(x => x.Email == email) > 0;
        }
    }
}