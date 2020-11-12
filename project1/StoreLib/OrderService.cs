using System.Collections.Generic;
using StoreDB.Repos;
using StoreDB.Models;
using System;

namespace StoreLib
{
    public class OrderService:IOrderService
    {
        private IOrderRepo repo;
        public OrderService(IOrderRepo repo)
        {
            this.repo = repo;
        }
        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }
        public void UpdateOrder(Order order)
        {
            repo.UpdateOrder(order);
        }
        public Order GetOrderById(int id)
        {
            return repo.GetOrderById(id);
        }
        public Order GetOrderByUserId(int id)
        {
            return repo.GetOrderByUserId(id);
        }
        public Order GetOrderByLocationId(int id)
        {
            return repo.GetOrderByLocationId(id);
        }
        public List<Order> GetAllOrdersByLocationId(int id)
        {
            List<Order> results = repo.GetAllOrdersByLocationId(id);
            return results;
        }
        public List<Order> GetAllOrdersByUserId(int id)
        {
            List<Order> results = repo.GetAllOrdersByUserId(id);
            return results;
        }
        public void DeleteOrder(Order order)
        {
            repo.DeleteOrder(order);
        }

        public List<Order> GetAllOrdersByUserIdDateAsc(int id)
        {
            List<Order> results = repo.GetAllOrdersByUserIdDateAsc(id);
            return results;
        }
        public List<Order> GetAllOrdersByUserIdDateDesc(int id)
        {
            List<Order> results = repo.GetAllOrdersByUserIdDateDesc(id);
            return results;
        }
        public List<Order> GetAllOrdersByUserIdPriceAsc(int id)
        {
            List<Order> results = repo.GetAllOrdersByUserIdPriceAsc(id);
            return results;
        }
        public List<Order> GetAllOrdersByUserIdPriceDesc(int id)
        {
            List<Order> results = repo.GetAllOrdersByUserIdPriceDesc(id);
            return results;
        }

        public Order GetOrderByDate(DateTime dateTime)
        {
            return repo.GetOrderByDate(dateTime);
        }
    }
}
