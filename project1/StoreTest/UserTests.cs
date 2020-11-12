using Xunit;
using StoreDB.Models;
using StoreDB.Repos;
using StoreDB;
using System.Linq;
using System.Collections.Generic;

namespace StoreTest
{
    public class UserTests
    {
        [Fact]
        public void AddUser() 
        {
            using var context = new StoreContext();
            IUserRepo repo = new DBRepo(context);

            User user = new User();
            user.Name = "testuser";
            user.Email = "test@test.org";
            user.Username = "test";
            user.Password = "pw1234";
            user.Type = 0;
            user.LocationId = 1;

            repo.AddUser(user);

            Assert.NotNull(context.Users.Single(q => q.UserId == user.UserId));
            repo.DeleteUser(user);
        }
        [Fact]
        public void UpdateUser()
        {
            using var context = new StoreContext();
            IUserRepo repo = new DBRepo(context);

            User user = new User();
            user.Name = "testuser";
            user.Email = "test@test.org";
            user.Username = "test";
            user.Password = "pw1234";
            user.Type = 0;
            user.LocationId = 1;

            repo.AddUser(user);

            user.Name = "M";
            repo.UpdateUser(user);
            Assert.Equal("M", user.Name);

            repo.DeleteUser(user);

        }
        [Fact]
        public void GetUserById()
        {
            using var context = new StoreContext();
            IUserRepo repo = new DBRepo(context);

            User user = new User();
            user.Name = "testuser";
            user.Email = "test@test.org";
            user.Username = "test";
            user.Password = "pw1234";
            user.Type = 0;
            user.LocationId = 1;

            repo.AddUser(user);

            Assert.NotNull(repo.GetUserById(user.UserId).Name);
            repo.DeleteUser(user);
        }
        [Fact]
        public void GetUserByUsername()
        {
            using var context = new StoreContext();
            IUserRepo repo = new DBRepo(context);

            User user = new User();
            user.Name = "testuser";
            user.Email = "test@test.org";
            user.Username = "test";
            user.Password = "pw1234";
            user.Type = 0;
            user.LocationId = 1;

            repo.AddUser(user);

            Assert.NotNull(repo.GetUserByUsername(user.Username).Name);
            repo.DeleteUser(user);
        }
        [Fact]
        public void GetAllUsers()
        {
            using var context = new StoreContext();
            IUserRepo repo = new DBRepo(context);

            User user = new User();
            user.Name = "testuser";
            user.Email = "test@test.org";
            user.Username = "test";
            user.Password = "pw1234";
            user.Type = 0;
            user.LocationId = 1;

            repo.AddUser(user);

            Assert.NotNull(repo.GetAllUsers());
            repo.DeleteUser(user);
        }
    }
}
