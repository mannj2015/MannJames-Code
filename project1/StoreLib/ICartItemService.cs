using StoreDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreLib
{
    public interface ICartItemService
    {
        public void AddCartItem(CartItem cart);
        public void UpdateCartItem(CartItem cartItem);
        public CartItem GetCartItemById(int cartItemId);
/*        public CartItem GetCartItemByCartId(int cartId);*/
        public List<CartItem> GetAllCartItemsByCartId(int cartId);
        public void DeleteCartItem(CartItem cart);
    }
}
