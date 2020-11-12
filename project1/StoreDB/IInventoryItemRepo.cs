using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface IInventoryItemRepo
    {
        public void AddInventoryItem(InventoryItem inventoryItem);
        public void UpdateInventoryItem(InventoryItem inventoryItem);
        public InventoryItem GetInventoryItemById(int id);
        public List<InventoryItem> GetAllInventoryItemsById(int id);
/*        InventoryItem GetInventoryItemByLocationId(int id);*/
        public List<InventoryItem> GetAllInventoryItemsByLocationId(int id);
        public void DeleteInventoryItem(InventoryItem inventoryItem);
        public InventoryItem GetItemByLocationIdProductId(int locationId, int productId);
    }
}