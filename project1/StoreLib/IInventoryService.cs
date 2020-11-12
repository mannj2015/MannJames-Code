using System;
using System.Collections.Generic;
using System.Text;
using StoreDB.Models;

namespace StoreLib
{
    public interface IInventoryService
    {
        public void AddInventoryItem(InventoryItem item);
        public void UpdateInventoryItem(InventoryItem item);
        public InventoryItem GetInventoryItemById(int id);
        public List<InventoryItem> GetAllInventoryItemsById(int id);
        public List<InventoryItem> GetAllInventoryItemsByLocationId(int id);
        public void DeleteInventoryItem(InventoryItem item);
        public InventoryItem GetItemByLocationIdProductId(int locationId, int productId);
    }
}