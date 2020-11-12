using System;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.Manager
{
    public class EditInventoryMenu : IMenu
    {
        private string userInput;
        private Product selectedProduct;
        private int selectedLocationId;
        private InventoryItem selectedItem;
        private User signedInUser;
        private StoreContext context;

        private IInventoryItemRepo inventoryItemRepo;
        private ILocationRepo locationRepo;
        private IProductRepo productRepo;

        private LocationService locationService;
        private InventoryService inventoryService;
        private ProductService productService;

        public EditInventoryMenu
            (User user, StoreContext context, ILocationRepo locationRepo,
            IInventoryItemRepo inventoryItemRepo, IProductRepo productRepo)
        {
            this.signedInUser = user;
            this.context = context;
            this.locationRepo = locationRepo;
            this.inventoryItemRepo = inventoryItemRepo;
            this.productRepo = productRepo;
            this.locationService = new LocationService(locationRepo);
            this.inventoryService = new InventoryService(inventoryItemRepo);
            this.productService = new ProductService(productRepo);
        }

        public void Start()
        {
            {
                do
                {
                    Console.WriteLine("\nSelect location to manage: ");

                    List<Location> locs = locationService.GetAllLocations();
                    foreach (Location loc in locs)
                    {
                        Console.WriteLine($" [{loc.LocationId}] {loc.StreetNumber} {loc.Street} " +
                            $"{loc.City} {loc.State} {loc.ZipCode} ");
                    }
                    Console.WriteLine("[3] Back");
                    userInput = Console.ReadLine();
                    selectedLocationId = Int32.Parse(userInput);

                    switch (userInput)
                    {
                        case "1":
                            EditInventory(1);
                            break;

                        case "2":
                            EditInventory(2);
                            break;

                        case "3":
                            break;

                        default:
                            ValidationService.InvalidInput();
                            break;
                    }

                } while (!userInput.Equals("3"));
            }
        }

        public List<InventoryItem> GetProductsForLocation(int locationId)
        {
            List<InventoryItem> items = inventoryService.GetAllInventoryItemsByLocationId(locationId);
            return items;
        }

        public void EditInventory(int locationId)
        {
            string input;

                do
                {
                    Console.WriteLine("\nSelect item to restock: ");

                    List<InventoryItem> items = GetProductsForLocation(locationId);
                    foreach (InventoryItem item in items)
                    {
                        Product product = productService.GetProductByProductId(item.ProductId);
                        Console.WriteLine($" [{product.ProductId}] {product.ProductName} | {product.Price} | " +
                            $"Quantity: {item.Quantity} ");
                    }
                    Console.WriteLine("[0] Back");

                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Restock(1);
                            break;

                        case "2":
                            Restock(2);
                            break;

                        case "3":
                            Restock(3);
                            break;

                        case "4":
                            Restock(4);
                            break;

                        case "5":
                            Restock(5);
                            break;

                        case "6":
                            Restock(6);
                            break;

                        case "7":
                            Restock(7);
                            break;

                        case "8":
                            Restock(8);
                            break;

                        case "9":
                            Restock(9);
                            break;

                        case "0":
                            break;

                        default:
                            ValidationService.InvalidInput();
                            break;
                    }

                } while (!input.Equals("0"));

            }

        public void Restock(int productId)
        {
            selectedItem = inventoryService.GetItemByLocationIdProductId(selectedLocationId, productId);
            Console.WriteLine("\nHow many would you like to add to the current stock?");
            int amount = Int32.Parse(Console.ReadLine());

            selectedItem.Quantity = amount + selectedItem.Quantity;
            inventoryService.UpdateInventoryItem(selectedItem);

            Console.WriteLine("Order submitted!");
        }
    }
}