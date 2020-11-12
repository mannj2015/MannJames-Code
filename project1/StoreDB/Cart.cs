using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("FK_CartUser")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<CartItem> CartItems { get; set; }

    }
}