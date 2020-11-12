using System;
using System.Collections.Generic;
using StoreDB.Models;
using StoreDB.Repos;
using StoreLib;

namespace StoreUI.Menus.Customer
{
    public class OrderHistoryMenu: IMenu
    {
        private string userInput;
        private User loggedInUser;

        private ILineItemRepo lineItemRepo;
        private ILocationRepo locationRepo;
        private IOrderRepo orderRepo;
        private IUserRepo userRepo;

        private LineItemService lineItemService;
        private LocationService locationService;
        private OrderService orderService;
        private ProductService productService;
        private UserService userService;

        public OrderHistoryMenu(User user, StoreContext storeContext,
            ILineItemRepo lineItemRepo, ILocationRepo locationRepo,
            IOrderRepo orderRepo, IUserRepo userRepo)
        {
            this.loggedInUser = user;
            this.lineItemRepo = lineItemRepo;
            this.locationRepo = locationRepo;
            this.orderRepo = orderRepo;
            this.userRepo = userRepo;

            this.lineItemService = new LineItemService(lineItemRepo);
            this.locationService = new LocationService(locationRepo);
            this.orderService = new OrderService(orderRepo);
            this.userService = new UserService(userRepo);
        }

        public void Start()
        {
            do
            {
                //TODO add ability to view order history by locations (select a location before the orders are displayed)

                Console.WriteLine("How would you like to view your previous orders? ");

                Console.WriteLine("[1] Sort By Date - Ascending Order");
                Console.WriteLine("[2] Sort By Date - Descending Order");
                Console.WriteLine("[3] Sort By Price - Ascending Order");
                Console.WriteLine("[4] Sort By Price - Descending Order");
                Console.WriteLine("[5] Back");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetOrdersSortedByDateAsc();
                        break;

                    case "2":
                        GetOrdersSortedByDateDesc();
                        break;

                    case "3":
                        GetOrdersSortedByPriceAsc();
                        break;

                    case "4":
                        GetOrdersSortedByPriceDesc();
                        break;

                    case "5":
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while (!userInput.Equals("5"));
        }

        public void GetOrdersSortedByDateAsc()
        {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdDateAsc(loggedInUser.UserId);
            foreach (Order order in orders)
            {
                Location location = locationService.GetLocationById(order.LocationId);
                Console.WriteLine($" Date: {order.OrderDate} | Total: {order.TotalPrice} | " +
                    $"Location: {location.City}, {location.State} {location.ZipCode} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.OrderId);
                foreach (LineItem item in items)
                {
                    Product product = productService?.GetProductByProductId(item.ProductId);
                    Console.WriteLine($"\tProduct: {product?.ProductName} | Price: {product?.Price} | " +
                        $"Amount: {item?.Quantity}");
                }
                Console.WriteLine("\n");
            }
        }

        public void GetOrdersSortedByDateDesc()
        {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdDateDesc(loggedInUser.UserId);
            foreach (Order order in orders)
            {
                Location location = locationService.GetLocationById(order.LocationId);
                Console.WriteLine($" Date: {order.OrderDate} | Total: {order.TotalPrice} | " +
                    $"Location: {location.City}, {location.State} {location.ZipCode} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.OrderId);
                foreach (LineItem item in items)
                {
                    //issue with line item retrieval?
                    //issue with order retrieval?
                    Product product = productService?.GetProductByProductId(item.ProductId);
                    Console.WriteLine($"\tProduct: {product?.ProductName} | Price: {item?.Price} | " +
                        $"Amount: {item?.Quantity}");
                }
                Console.WriteLine("\n");
            }
        }

        public void GetOrdersSortedByPriceAsc()
        {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdPriceAsc(loggedInUser.UserId);
            foreach (Order order in orders)
            {
                Location location = locationService.GetLocationById(order.LocationId);
                Console.WriteLine($" Date: {order.OrderDate} | Total: {order.TotalPrice} | " +
                    $"Location: {location.City}, {location.State} {location.ZipCode} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.OrderId);
                foreach (LineItem item in items)
                {
                    Product product = productService?.GetProductByProductId(item.ProductId);
                    Console.WriteLine($"\tProduct: {product?.ProductName} | Price: {item?.Price} | " +
                        $"Amount: {item?.Quantity}");
                }
                Console.WriteLine("\n");
            }
        }

        public void GetOrdersSortedByPriceDesc()
        {
            Console.WriteLine("\nPrevious orders: ");

            List<Order> orders = orderService.GetAllOrdersByUserIdPriceDesc(loggedInUser.UserId);
            foreach (Order order in orders)
            {
                Location location = locationService.GetLocationById(order.LocationId);
                Console.WriteLine($" Date: {order.OrderDate} | Total: {order.TotalPrice} | " +
                    $"Location: {location.City}, {location.State} {location.ZipCode} ");

                Console.WriteLine($"\tLine Items: ");
                List<LineItem> items = lineItemService.GetAllLineItemsByOrderId(order.OrderId);
                foreach (LineItem item in items)
                {
                    Product product = productService?.GetProductByProductId(item.ProductId);
                    Console.WriteLine($"\tProduct: {product?.ProductName} | Price: {item?.Price} | " +
                        $"Amount: {item?.Quantity}");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
