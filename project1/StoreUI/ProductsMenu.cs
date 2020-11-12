using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.Customer
{
    public class ProductsMenu : IMenu
    {
        private string userInput;
        private Product selectedProduct;
        private User loggedInUser;
        private StoreContext context;

        private IUserRepo userRepo;
        private IInventoryItemRepo inventoryItemRepo;
        private IProductRepo productRepo;

        private UserService userService;
        private InventoryService inventoryService;
        private ProductService productService;

        private ProductDetailsMenu productDetailsMenu;

        public ProductsMenu(User user, StoreContext context, IUserRepo userRepo, 
            IInventoryItemRepo inventoryItemRepo, IProductRepo productRepo)
        {
            this.loggedInUser = user;
            this.context = context;
            this.userRepo = userRepo;
            this.productRepo = productRepo;
            this.inventoryItemRepo = inventoryItemRepo;

            this.userService = new UserService(userRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.productService = new ProductService(productRepo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("\nSelect a product: ");

                List<InventoryItem> items = GetProductsForUserLocation();
                foreach (InventoryItem item in items)
                {
                    Product product = productService.GetProductByProductId(item.ProductId);
                    Console.WriteLine($" [{product.ProductId}] {product.ProductName} | | {product.Price} | " +
                        $"Quantity: {item.Quantity} ");
                }

                Console.WriteLine("[0] Back");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        selectedProduct = productService.GetProductByProductId(1);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct, 
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context), 
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        //fix in productsmenu
                        break;

                    case "2":
                        selectedProduct = productService.GetProductByProductId(2);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "3":
                        selectedProduct = productService.GetProductByProductId(3);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "4":
                        selectedProduct = productService.GetProductByProductId(4);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "5":
                        selectedProduct = productService.GetProductByProductId(5);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "6":
                        selectedProduct = productService.GetProductByProductId(6);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "7":
                        selectedProduct = productService.GetProductByProductId(7);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "8":
                        selectedProduct = productService.GetProductByProductId(8);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "9":
                        selectedProduct = productService.GetProductByProductId(9);
                        productDetailsMenu = new ProductDetailsMenu(loggedInUser, selectedProduct,
                            context, new DBRepo(context), new DBRepo(context), new DBRepo(context),
                            new DBRepo(context), new DBRepo(context));
                        productDetailsMenu.Start();
                        break;

                    case "0":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }
            } while (!userInput.Equals("0"));
        }

        public List<InventoryItem> GetProductsForUserLocation()
        {
            List<InventoryItem> items;
            int locationId = loggedInUser.LocationId;
            items = inventoryService.GetAllInventoryItemsByLocationId(locationId);
            return items;
        }
    }
}