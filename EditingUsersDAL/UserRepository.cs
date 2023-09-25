using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using User = BusinessLogic.User;

namespace EditingUsersDAL
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDBContext db;

        public UserRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(Guid id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User GetItem(Guid id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetItemList()
        {
            return db.Users.Include(x => x.Permissions);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}
