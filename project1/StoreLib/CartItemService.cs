using StoreDB.Repos;
using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public class CartItemService: ICartItemService
    {
        private ICartItemRepo repo;
        public CartItemService(ICartItemRepo repo)
        {
            this.repo = repo;
        }
        public void AddCartItem(CartItem cart)
        {
            repo.AddCartItem(cart);
        }
        public void UpdateCartItem(CartItem cartItem)
        {
            repo.UpdateCartItem(cartItem);
        }

/*        public CartItem GetCartItemByCartId(int id)
        {
            CartItem result = repo.GetCartItemByCartId(id);
            return result;
        }*/
        public List<CartItem> GetAllCartItemsByCartId(int cartId)
        {
            List<CartItem> resultList = repo.GetAllCartItemsByCartId(cartId);
            return resultList;
        }
        public void DeleteCartItem(CartItem cart)
        {
            repo.DeleteCartItem(cart);
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            CartItem result = repo.GetCartItemById(cartItemId);
            return result;
        }

        /*        public CartItem GetCartItemByCartId(int cartId)
                {
                    CartItem result = repo.GetCartItemById(cartId);
                    return result;
                }*/
    }
}