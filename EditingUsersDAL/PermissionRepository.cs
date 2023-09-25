using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class PermissionRepository : IRepository<Permission>
    {
        private ApplicationDBContext db;

        public PermissionRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(Permission item)
        {
            db.Permissions.Add(item);
        }
        public IEnumerable<Permission> GetItemList()
        {
            return db.Permissions;
        }

        public void CreateList(IEnumerable<Permission> list)
        {
            db.Permissions.AddRange(list);
        }

        public void Delete(Guid id)
        {
            Permission permission = db.Permissions.Find(id);
            if (permission != null)
                db.Permissions.Remove(permission);
        }

        public Permission GetItem(Guid id)
        {
            return db.Permissions.Find(id);
        }

        public IEnumerable<Permission> GetUserList()
        {
            return db.Permissions;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Permission item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


    }
}
