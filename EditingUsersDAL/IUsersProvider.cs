using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public interface IUsersProvider
    {
        public List<User> GetAllUsers();
        public void AddUser(User user);
        public void DeleteUser(User user);
        public void UpdateUser(User user);
        public void AddModule(Modules modules);
    }
}
