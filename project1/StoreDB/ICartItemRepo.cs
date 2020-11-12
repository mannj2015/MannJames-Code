using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface ICartItemRepo
    {
        public void AddCartItem(CartItem cart);
        public void UpdateCartItem(CartItem cartItem);
        public CartItem GetCartItemById(int cartItemId);
        public List<CartItem> GetAllCartItemsByCartId(int cartId);
        public void DeleteCartItem(CartItem cart);
    }
}
