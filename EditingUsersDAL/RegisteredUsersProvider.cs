using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class RegisteredUsersProvider : IUsersProvider
    {
        public List<User> GetAllUsers()
        {
            List<User> list;
            using (var context = new ApplicationContext())
            {
                list = context.Users.ToList();
            }
            return list;
        }

        public void AddUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void AddModule(Modules modules)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Modules.Add(modules);
                db.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Update(user);
                db.SaveChanges();
            }
        }


    }
}
