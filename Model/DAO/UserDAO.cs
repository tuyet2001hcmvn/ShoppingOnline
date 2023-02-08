using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class UserDAO
    {
        ShoppingOnlineDBContext db = null;
        public UserDAO()
        {
            db = new ShoppingOnlineDBContext();
        }
        public int Login(string username, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == username);
            if (result == null)
                return 0;
            else
            {
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == password)
                        return 1;
                    else
                        return -2;
                }

            }
        }

        public List<User> lstAllUser()
        {
            var res = db.Database.SqlQuery<User>("SP_SelectAll_User").ToList();
            return res;
        }

        public IEnumerable<User> Paging(string strSearch, int page, int pagesize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(strSearch))
                model = model.Where(x => x.UserName.Contains(strSearch) || x.Name.Contains(strSearch));
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }

        public User GetByID(string username)
        {
            return db.Users.SingleOrDefault(x => x.UserName == username);
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public long Update(User entity)
        {
            var user = db.Users.Find(entity.ID);
            user.Name = entity.Name;
            if (entity.Password != null)
                user.Password = entity.Password;
            user.Email = entity.Email;
            user.Address = entity.Address;
            user.Phone = entity.Phone;
            user.Status = entity.Status;
            user.ModifiedDate = DateTime.Now;
            db.SaveChanges();
            return entity.ID;
        }
        public long Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return 1;
        }

        public bool Changestatus(int id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

    }
}
