using StoreDB.Models;
using StoreDB.Repos;
using StoreLib;
using StoreUI.Menus;
using System;
using System.Collections.Generic;
using System.Text;

//check line 62

namespace StoreUI.Menus.Customer
{
    public class ProductDetailsMenu : IMenu
    {
        private string userInput;
        private User loggedInUser;

        private ICartRepo cartRepo;
        private ICartItemRepo cartItemRepo;
        private IInventoryItemRepo inventoryItemRepo;
        private ILineItemRepo lineItemRepo;
        private ILocationRepo locationRepo;
        private IOrderRepo orderRepo;
        private IProductRepo productRepo;
        private IUserRepo userRepo;

        private Product product;
        private CartService cartService;
        private CartItemService cartItemService;
        private InventoryService inventoryService;
        private LineItemService lineItemService;
        private LocationService locationService;
        private OrderService orderService;
        private ProductService productService;
        private UserService userService;
        public ProductDetailsMenu(User user, Product product, StoreContext context, IUserRepo userRepo,
            IInventoryItemRepo inventoryItemRepo, IProductRepo productRepo, ICartRepo cartRepo,
            ICartItemRepo cartItemRepo)
        {
            this.loggedInUser = user;
            this.product = product;

            this.userRepo = userRepo;
            this.productRepo = productRepo;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.inventoryItemRepo = inventoryItemRepo;

            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.productService = new ProductService(productRepo);
            this.userService = new UserService(userRepo);
        }

            public void Start()
            {
                do
                {
                    InventoryItem selectedItem = inventoryService
                        .GetItemByLocationIdProductId(loggedInUser.LocationId, product.ProductId);
                //fix here
                    int inventoryQuantity = selectedItem.Quantity;

                    Console.WriteLine("\nWhat would you like to do? ");

                    Console.WriteLine($" [{product.ProductId}] {product.ProductName} | {product.Price} " +
                        $"| Amount: {inventoryQuantity} ");

                    Console.WriteLine("[1] Add to cart");
                    Console.WriteLine("[2] Back");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            int quantity;
                            do
                            {
                                Console.WriteLine("How many would you like? ");
                                quantity = Int32.Parse(Console.ReadLine());
                            } while (ValidationService.InvalidQuantity(inventoryQuantity, quantity) 
                            == false);

                            CartItem item = new CartItem();
                            Cart userCart = cartService.GetCartByUserId(loggedInUser.UserId);
                            item.CartId = userCart.CartId;
                            item.ProductId = product.ProductId;
                            item.Quantity = quantity;
                        if (item != null)
                        {
                            cartItemService.AddCartItem(item);
                        }
                        else { Console.WriteLine("error. try adding again"); break; }
                            Console.WriteLine($"{product.ProductName} added to cart!");
                            break;

                        case "2":
                            break;

                        default:
                            ValidationService.InvalidInput();
                            break;
                    }
                } while (!userInput.Equals("2"));
            }
     }
}
