﻿using BusinessLogic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditingUsersDAL
{
    public class PostgreSQLModelsRepository 
    {
        private ApplicationDBContext db;

        public PostgreSQLModelsRepository()
        {
            db = new ApplicationDBContext();
        }

        public void Create(Module module)
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

        public Module GetUser(Guid id)
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

        public void Update(Module item)
        {
            throw new NotImplementedException();
        }
    }
}
