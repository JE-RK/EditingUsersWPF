using BusinessLogic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class PostgreSQLModelsRepository : IRepository<Modules>
    {
        private ApplicationDBContext db;

        public PostgreSQLModelsRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(Modules module)
        {
            db.Modules.Add(module);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Modules GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modules> GetUserList()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Modules item)
        {
            throw new NotImplementedException();
        }
    }
}
