using BusinessLogic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class ModuleRepository 
    {
        private ApplicationDBContext db;

        public ModuleRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(Module module)
        {
            db.Modules.Add(module);
        }

        public Module GetItem(Guid id)
        {
            return db.Modules.Find(id);
        }

        public IEnumerable<Module> GetUserList()
        {
            return db.Modules;
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
