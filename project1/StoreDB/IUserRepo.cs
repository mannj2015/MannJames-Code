using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface IUserRepo
    {
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User GetUserById(int id);
        public User GetUserByUsername(string username);
        public List<User> GetAllUsers();
        public void DeleteUser(User user);
    }
}