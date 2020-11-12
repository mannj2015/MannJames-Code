using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class LineItem
    {
        [Key]
        public int LIId { get; set; }
        [ForeignKey("FK_LineOrder")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("FK_LineProduct")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

    }
}
