using Microsoft.VisualStudio.TestTools.UnitTesting;
using EditingUsersDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace EditingUsersDAL.Tests
{
    [TestClass()]
    public class RegisteredUsersProviderTests
    {
        IUsersProvider provider;
        List<Modules> modules;
        byte[] userPhoto;
        User user;
        [TestInitialize]
        public void TestInitialize()
        {
            provider = new RegisteredUsersProvider();
            userPhoto = File.ReadAllBytes(@"C:\Users\d-bel\Downloads\kinozpis.jpg");
            modules = new List<Modules>
            {
                new Modules {Id = Guid.NewGuid(), Name="Продажи"},
                new Modules {Id = Guid.NewGuid(), Name="Закупки"},
                new Modules {Id = Guid.NewGuid(), Name="Аналитика"},
                new Modules {Id = Guid.NewGuid(), Name="Администрирование"},
            };
            user = new User
            {
                FirstName = "Дмитрий",
                LastName = "Беломытцев",
                MiddleName = "Сергеевич",
                Birthday = new DateTime(2005, 3, 31),
                Gender = User.Genders.Man,
                IsBlocked = false,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Id = Guid.NewGuid(),
                Photo = userPhoto
            };
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddUserTest()
        {
            provider.AddUser(user);
        }

        [TestMethod()]
        public void AddModuleTest()
        {
            foreach (var item in modules)
            {
                provider.AddModule(item);
            }
            
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            Assert.Fail();
        }
    }
}