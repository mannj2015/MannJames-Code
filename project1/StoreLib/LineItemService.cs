using System.Collections.Generic;
using StoreDB.Repos;
using StoreDB.Models;

namespace StoreLib
{
    public class LineItemService:ILineItemService
    {
        private ILineItemRepo repo;
        public LineItemService(ILineItemRepo repo)
        {
            this.repo = repo;
        }

        public void AddLineItem(LineItem lineItem)
        {
            repo.AddLineItem(lineItem);
        }
        public void UpdateLineItem(LineItem lineItem)
        {
            repo.UpdateLineItem(lineItem);
        }
        public LineItem GetLineItemByOrderId(int id)
        {
            return repo.GetLineItemByOrderId(id);
        }
        public List<LineItem> GetAllLineItemsByOrderId(int id)
        {
            List<LineItem> results = repo.GetAllLineItemsByOrderId(id);
            return results;
        }
        public void DeleteLineItem(LineItem lineItem)
        {
            repo.DeleteLineItem(lineItem);
        }
    }
}
