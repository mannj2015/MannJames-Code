using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IUserService
    {
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
        public List<User> GetAllUsers();
        public void DeleteUser(User user);
    }
}