using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreDB.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public List<InventoryItem> Inventory { get; set; }

    }
}