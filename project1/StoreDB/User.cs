using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [ForeignKey("FK_UserLoc")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }

        public List<Order> Orders { get; set; }

        public enum UserType
        {
            Customer,
            Employee,
            Manager,
        }
    }
}
