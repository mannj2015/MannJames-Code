using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDB.Models
{
    public class InventoryItem
    {
        [Key]
        public int IIId { get; set; }
        [ForeignKey("FK_InvProd")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("FK_InvLoc")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        
        public int Quantity { get; set; }
    }
}