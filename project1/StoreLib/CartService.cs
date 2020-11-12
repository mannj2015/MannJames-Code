using StoreDB.Repos;
using StoreDB.Models;

namespace StoreLib
{
    public class CartService:ICartService
    {
        private ICartRepo repo;
        public CartService(ICartRepo repo)
        {
            this.repo = repo;
        }
        public void AddCart(Cart cart)
        {
            repo.AddCart(cart);
        }
        public void UpdateCart(Cart cart)
        {
            repo.UpdateCart(cart);
        }
        public Cart GetCartById(int id)
        {
            Cart result = repo.GetCartById(id);
            return result;
        }
        public Cart GetCartByUserId(int id)
        {
            Cart result = repo.GetCartByUserId(id);
            return result;
        }
        public void DeleteCart(Cart cart)
        {
            repo.DeleteCart(cart);
        }
    }
}
