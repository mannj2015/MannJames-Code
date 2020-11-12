using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface ILineItemService
    {
        public void AddLineItem(LineItem lineItem);
        public void UpdateLineItem(LineItem lineItem);
        public LineItem GetLineItemByOrderId(int id);
        public List<LineItem> GetAllLineItemsByOrderId(int id);
        public void DeleteLineItem(LineItem lineItem);
    }
}
