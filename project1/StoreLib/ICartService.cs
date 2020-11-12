using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface ICartService
    {
        public void AddCart(Cart cart);
        public void UpdateCart(Cart cart);
        public Cart GetCartById(int id);
        public Cart GetCartByUserId(int id);
        public void DeleteCart(Cart cart);
    }
}