using System;
using System.Collections.Generic;
using System.Text;
using StoreDB.Models;

namespace StoreLib
{
    public interface IOrderService
    {
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public Order GetOrderById(int id);
        public Order GetOrderByUserId(int id);
        public Order GetOrderByLocationId(int id);
        public List<Order> GetAllOrdersByLocationId(int id);
        public List<Order> GetAllOrdersByUserId(int id);
        public void DeleteOrder(Order order);
        public List<Order> GetAllOrdersByUserIdDateAsc(int id);
        public List<Order> GetAllOrdersByUserIdDateDesc(int id);
        public List<Order> GetAllOrdersByUserIdPriceAsc(int id);
        public List<Order> GetAllOrdersByUserIdPriceDesc(int id);

        public Order GetOrderByDate(DateTime dateTime);
    }
}