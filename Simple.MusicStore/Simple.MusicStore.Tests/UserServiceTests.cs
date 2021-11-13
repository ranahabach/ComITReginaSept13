using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using Simple.MusicStore.Tools.Data;
using Simple.MusicStore.Web.Data;
using Simple.MusicStore.Web.Services;

namespace Simple.MusicStore.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        // Arrange  Act  Assert 
        [TestMethod]
        public void Should_be_able_to_add_user()
        {
            var service = CreateSUT();

            var user = new User();
            user.FirstName = "Admin";
            user.LastName = "Admin";
            user.Email = "admin@musicstore.com";
            user.Password = "thePassword";

            service.Add(user);
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void Should_not_be_able_to_add_user_without_email()
        {
            var service = CreateSUT();

            var user = new User();
            user.FirstName = "Admin";
            user.LastName = "Admin";
            user.Email = "admin@musicstore.com";
            user.Password = "thePassword";

            service.Add(user);
        }

        [TestMethod]
        public void Should_be_able_to_find_user_by_email()
        {
            var service = CreateSUT();

            var user = service.Find("admin@musicstore.com");

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Email, "admin@musicstore.com");
        }


        [TestMethod]
        public void Should_be_able_get_all_users()
        {
            var service = CreateSUT();

            var users = service.GetAll();

            Assert.IsNotNull(users);
            Assert.AreEqual(users.Length, 1);
        }

        [TestMethod]
        public void Is_valid_password()
        {
            var service = CreateSUT();

            Assert.IsTrue(service.IsValidPassword("thePassword1"));
        }

        [TestMethod]
        public void No_capital_letter_is_not_valid_password()
        {
            var service = CreateSUT();

            Assert.IsFalse(service.IsValidPassword("thepassword"));
        }

        [TestMethod]
        public void No_number_is_not_valid_password()
        {
            var service = CreateSUT();

            Assert.IsFalse(service.IsValidPassword("thepassword"));
        }

        [TestMethod]
        public void Empty_not_valid_password()
        {
            var service = CreateSUT();

            Assert.IsFalse(service.IsValidPassword(string.Empty));
        }

        [TestMethod]
        public void Null_not_valid_password()
        {
            var service = CreateSUT();

            Assert.IsFalse(service.IsValidPassword(null));
        }

        [TestMethod]
        public void Spaces_not_valid_password()
        {
            var service = CreateSUT();

            Assert.IsFalse(service.IsValidPassword("       "));
        }

        private UserService CreateSUT()
        {
            return new UserService(GetDbContext());
        }

        private MusicStoreDbContext GetDbContext()
        {
            return new MusicStoreDbContext();
        }
    }
}
