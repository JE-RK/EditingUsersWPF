using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class PermissionRepository 
    {
        private ApplicationDBContext db;

        public PermissionRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(Permission item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Permission> GetPermissionList(Guid userId)
        {
            return db.Permissions.Where(p => p.UserId == userId); 
        }
        public void CreateList(IEnumerable<Permission> list)
        {
            db.Permissions.AddRange(list);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Permission GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Permission> GetUserList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Permission item)
        {
            throw new NotImplementedException();
        }
    }
}
