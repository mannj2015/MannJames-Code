using System.Collections.Generic;
using StoreDB.Models;
using StoreDB.Repos;

namespace StoreLib
{
    public class InventoryService:IInventoryService
    {
        private IInventoryItemRepo repo;
        public InventoryService(IInventoryItemRepo repo)
        {
            this.repo = repo;
        }

        public void AddInventoryItem(InventoryItem item)
        {
            repo.AddInventoryItem(item);
        }
        public void UpdateInventoryItem(InventoryItem item)
        {
            repo.UpdateInventoryItem(item);
        }
        public InventoryItem GetInventoryItemById(int id)
        {
            return repo.GetInventoryItemById(id);
        }
        public List<InventoryItem> GetAllInventoryItemsById(int id)
        {
            List<InventoryItem> results = repo.GetAllInventoryItemsById(id);
            return results;
        }
        public List<InventoryItem> GetAllInventoryItemsByLocationId(int id)
        {
            List<InventoryItem> results = repo.GetAllInventoryItemsByLocationId(id);
            return results;
        }
        public void DeleteInventoryItem(InventoryItem item)
        {
            repo.DeleteInventoryItem(item);
        }
        public InventoryItem GetItemByLocationIdProductId(int locationId, int productId)
        {
            return repo.GetItemByLocationIdProductId(locationId, productId);
        }
    }
}
