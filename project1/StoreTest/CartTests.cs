using System.Collections.Generic;
using System.Linq;
using StoreDB;
using StoreDB.Models;
using StoreDB.Repos;
using Xunit;

namespace StoreTest
{
    public class CartTests
    {
        #region Cart
        [Fact]
        public void AddCart()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;

            repo.AddCart(testCart);
            Assert.NotNull(context.Carts.Single(q => q.CartId == testCart.CartId));
            repo.DeleteCart(testCart);
        }
        [Fact]
        public void UpdateCart()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;
            repo.AddCart(testCart);

            testCart.UserId = 2;
            repo.UpdateCart(testCart);
            Assert.Equal(2, testCart.UserId);

            repo.DeleteCart(testCart);
        }
        [Fact]
        public void GetCartById()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;
            repo.AddCart(testCart);

            Assert.NotNull(repo.GetCartById(testCart.CartId));

            repo.DeleteCart(testCart);
        }
        [Fact]
        public void GetCartByUserId()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);

            Cart testCart12 = new Cart();
            testCart12.UserId = 2;
            repo.AddCart(testCart12);

            Assert.NotNull(repo.GetCartByUserId(testCart12.UserId));

            repo.DeleteCart(testCart12);
        }
        #endregion

        #region CartItems
        [Fact]
        public void AddCartItem()
        {
            using var context = new StoreContext();
            ICartRepo cartrepo = new DBRepo(context);
            ICartItemRepo cirepo = new DBRepo(context);

            //add cart
            Cart testCart3 = new Cart();
            testCart3.UserId = 2;
            cartrepo.AddCart(testCart3);

            //addcartitem
            CartItem cartItem2 = new CartItem();
            cartItem2.CartId = testCart3.CartId;
            cartItem2.ProductId = 1;
            cartItem2.Quantity = 5;
            cirepo.AddCartItem(cartItem2);

            //assert
            Assert.NotNull(context.CartItems.Single
            (
                q => q.CartItemId == cartItem2.CartItemId
            ));

            //cleanup
            cirepo.DeleteCartItem(cartItem2);
            cartrepo.DeleteCart(testCart3);
        }
        [Fact]
        public void UpdateCartItem()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);
            ICartItemRepo cirepo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;

            repo.AddCart(testCart);

            CartItem testCartItem = new CartItem();
            testCartItem.CartId = testCart.CartId;
            testCartItem.ProductId = 1;
            testCartItem.Quantity = 10;
            cirepo.AddCartItem(testCartItem);

            testCartItem.Quantity = 2;
            cirepo.UpdateCartItem(testCartItem);
            Assert.Equal(2, testCartItem.Quantity);

            cirepo.DeleteCartItem(testCartItem);
            repo.DeleteCart(testCart);
        }
        [Fact]
        public void GetCartItemById()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);
            ICartItemRepo cirepo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;

            repo.AddCart(testCart);

            CartItem testCartItem = new CartItem();
            testCartItem.ProductId = 1;
            testCartItem.Quantity = 10;
            testCartItem.CartId = testCart.CartId;
            cirepo.AddCartItem(testCartItem);

            Assert.NotNull(cirepo.GetCartItemById(testCartItem.CartItemId));

            cirepo.DeleteCartItem(testCartItem);
            repo.DeleteCart(testCart);
        }
        [Fact]
        public void GetCartItemByCartId()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);
            ICartItemRepo cirepo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;

            repo.AddCart(testCart);

            CartItem testCartItem = new CartItem();
            testCartItem.CartItemId = 1;
            testCartItem.ProductId = 1;
            testCartItem.Quantity = 10;
            testCartItem.CartId = testCart.CartId;
            cirepo.AddCartItem(testCartItem);

            Assert.NotNull(cirepo.GetAllCartItemsByCartId(testCartItem.CartItemId));

            cirepo.DeleteCartItem(testCartItem);
            repo.DeleteCart(testCart);
        }
        [Fact]
        public void GetAllCartItemsByCartId()
        {
            using var context = new StoreContext();
            ICartRepo repo = new DBRepo(context);
            ICartItemRepo cirepo = new DBRepo(context);

            Cart testCart = new Cart();
            testCart.UserId = 1;

            repo.AddCart(testCart);

            CartItem testCartItem = new CartItem();
            testCartItem.CartId = testCart.CartId;
            testCartItem.ProductId = 1;
            testCartItem.Quantity = 10;
            cirepo.AddCartItem(testCartItem);

            List<CartItem> items = cirepo.GetAllCartItemsByCartId(testCartItem.CartItemId);
            Assert.NotNull(items);

            cirepo.DeleteCartItem(testCartItem);
            repo.DeleteCart(testCart);
        }
        #endregion
    }
}