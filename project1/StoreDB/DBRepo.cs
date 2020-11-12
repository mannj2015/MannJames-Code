using StoreDB.Models;
using StoreDB.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreDB
{
    public class DBRepo : IProductRepo, ILocationRepo, IInventoryItemRepo, 
        ICartItemRepo, ICartRepo, IUserRepo, ILineItemRepo, IOrderRepo
    {
        private StoreContext context;
        public DBRepo(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Methods to affect product
        /// </summary>
        /// <param name="product"></param>

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.Select(x => x).ToList();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.SingleOrDefault(x => x.ProductId == productId);
        }

        public Product GetProductByName(string productName)
        {
            return context.Products.SingleOrDefault(x => x.ProductName == productName);
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        /// <summary>
        /// Manipulate Location Info
        /// </summary>
        /// <param name="location"></param>

        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            context.Locations.Remove(location);
            context.SaveChanges();
        }
        public List<Location> GetAllLocations()
        {
            return context.Locations.Select(x => x).ToList();
        }

        public void UpdateLocation(Location location)
        {
            context.Locations.Update(location);
        }

        public List<Location> GetLocationByState(string state)
        {
            return context.Locations.Where(x => x.State == state).ToList();
        }

        public List<Location> GetLocationByCity(string city)
        {
            return context.Locations.Where(x => x.City == city).ToList();
        }

        public List<Location> GetLocationByZipcode(string zipcode)
        {
            return context.Locations.Where(x => x.ZipCode == zipcode).ToList();
        }

        public Location GetLocationById(int id)
        {
            return context.Locations.SingleOrDefault(x => x.LocationId == id);
        }

        /// <summary>
        /// Items in inventory get affected
        /// </summary>
        /// <param name="inventoryItem"></param>

        public void AddInventoryItem(InventoryItem inventoryItem)
        {
            context.InventoryItems.Add(inventoryItem);
            context.SaveChanges();
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            context.InventoryItems.Update(inventoryItem);
            context.SaveChanges();
        }

/*        public InventoryItem GetInventoryItemById(int id)
        {
            return context.InventoryItems.SingleOrDefault(x => x.IIId == id);
        }*/

        public List<InventoryItem> GetAllInventoryItemsById(int id)
        {
            return context.InventoryItems.Where(x => x.IIId == id).ToList();
        }

        public InventoryItem GetInventoryItemByLocationId(int id)
        {
            return context.InventoryItems.SingleOrDefault(x => x.LocationId == id);
        }

        public List<InventoryItem> GetAllInventoryItemsByLocationId(int id)
        {
            return context.InventoryItems.Where(x => x.LocationId == id).ToList();
        }

        public void DeleteInventoryItem(InventoryItem inventoryItem)
        {
            context.InventoryItems.Remove(inventoryItem);
            context.SaveChanges();
        }

        //returns null
        public InventoryItem GetItemByLocationIdProductId(int locationId, int productId)
        {
            return context.InventoryItems
                .FirstOrDefault(x => x.LocationId == locationId && x.ProductId == productId);
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            return context.InventoryItems.SingleOrDefault(x => x.IIId == id);
        }

        /// <summary>
        /// Cart item methods
        /// </summary>
        /// <param name="cart"></param>
        public void AddCartItem(CartItem cart)
        {
            context.CartItems.Add(cart);
            context.SaveChanges();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            context.CartItems.Update(cartItem);
            context.SaveChanges();
        }

        public CartItem GetCartItemById(int id)
        {
            return context.CartItems.SingleOrDefault(x => x.CartItemId == id);
        }

        //TODO change name for method
        public CartItem GetCartItemByCartId(int id)
        {
            return context.CartItems.SingleOrDefault(x => x.CartId == id);
        }

        //TODO test this
        public List<CartItem> GetAllCartItemsByCartId(int id)
        {
            return context.CartItems.Where(x => x.CartId == id).ToList();
        }

        public void DeleteCartItem(CartItem cart)
        {
            context.CartItems.Remove(cart);
            context.SaveChanges();
        }

        /// <summary>
        /// Cart manipulation
        /// </summary>
        /// <param name="cart"></param>
        public void AddCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
            context.SaveChanges();
        }

        public Cart GetCartById(int id)
        {
            return context.Carts.SingleOrDefault(x => x.CartId == id);
        }

        public Cart GetCartByUserId(int id)
        {
            return context.Carts.SingleOrDefault(x => x.UserId == id);
        }

        public void DeleteCart(Cart cart)
        {
            //somehow null
            context.Carts.Remove(cart);
            context.SaveChanges();
        }
        /// <summary>
        /// User methods run
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return context.Users.SingleOrDefault(q => q.UserId == id);
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(q => q.Username==username);
        }

        public List<User> GetAllUsers()
        {
            return context.Users.Select(q => q).ToList();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        /// <summary>
        /// Line Item methods
        /// </summary>
        /// <param name="lineItem"></param>

        public void AddLineItem(LineItem lineItem)
        {
            context.LineItems.Add(lineItem);
            context.SaveChanges();
        }

        public void UpdateLineItem(LineItem lineItem)
        {
            context.LineItems.Update(lineItem);
            context.SaveChanges();
        }

        public LineItem GetLineItemByOrderId(int id)
        {
            return context.LineItems.SingleOrDefault(q => q.OrderId == id);
        }

        //problem here
        public List<LineItem> GetAllLineItemsByOrderId(int id)
        {
            return context.LineItems.Where(q => q.OrderId == id).ToList();
        }

        public void DeleteLineItem(LineItem lineItem)
        {
            context.LineItems.Remove(lineItem);
            context.SaveChanges();
        }
        /// <summary>
        /// order methods (including sorting by date and cost)
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.SingleOrDefault(q => q.OrderId ==id);
        }

        public Order GetOrderByUserId(int id)
        {
            return context.Orders.SingleOrDefault(q => q.UserId == id);
        }

        public Order GetOrderByLocationId(int id)
        {
            return context.Orders.SingleOrDefault(q => q.LocationId == id);
        }

        public List<Order> GetAllOrdersByLocationId(int id)
        {
            return context.Orders.Where(q => q.LocationId == id).ToList();
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            return context.Orders.Where(q => q.UserId == id).ToList();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public List<Order> GetAllOrdersByUserIdDateAsc(int id)
        {
            return context.Orders.Where(x => x.UserId == id)
                .OrderBy(x => x.OrderDate).ToList();
        }

        public List<Order> GetAllOrdersByUserIdDateDesc(int id)
        {
            return context.Orders.Where(x => x.UserId == id)
                .OrderByDescending(x => x.OrderDate).ToList();
        }

        public List<Order> GetAllOrdersByUserIdPriceAsc(int id)
        {
            return context.Orders.Where(x => x.UserId == id)
                .OrderBy(x => x.TotalPrice).ToList();
        }

        public List<Order> GetAllOrdersByUserIdPriceDesc(int id)
        {
            return context.Orders.Where(x => x.UserId == id)
                .OrderByDescending(x => x.TotalPrice).ToList();
        }

        public Order GetOrderByDate(DateTime dateTime)
        {
            return context.Orders.SingleOrDefault(q => q.OrderDate == dateTime);
        }
    }
}
