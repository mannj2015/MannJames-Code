using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("FK_OrderUser")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("FK_OrderLoc")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}