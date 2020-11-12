using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;

namespace StoreUI.Menus.Customer
{
    public class CustomerMenu : IMenu
    {
        private string userInput;
        private User loggedInUser;
        private ProductsMenu productsMenu;
        private OrderHistoryMenu orderHistoryMenu;
        private ChangeLocationMenu changeLocationMenu;
        private CartMenu cartMenu;

        public CustomerMenu(User user, StoreContext context)
        {
            this.loggedInUser = user;

            this.productsMenu = new ProductsMenu(loggedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context));

            this.orderHistoryMenu = new OrderHistoryMenu(loggedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));

            this.changeLocationMenu = new ChangeLocationMenu(loggedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
            
            this.cartMenu = new CartMenu(loggedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }
        public void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome to Mann's Videogame Shoppe {loggedInUser.Name}!");
                Console.WriteLine("\nWhat would you like to do today?");

                //Customer Menu Options
                System.Console.WriteLine("[1] View Products");
                System.Console.WriteLine("[2] View Order History");
                System.Console.WriteLine("[3] Change Location");
                System.Console.WriteLine("[4] View Cart");
                System.Console.WriteLine("[5] Exit");
                userInput = System.Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        productsMenu.Start();
                        break;

                    case "2":
                        orderHistoryMenu.Start();
                        break;

                    case "3":
                        changeLocationMenu.Start();
                        break;

                    case "4":
                        cartMenu.Start();
                        break;

                    case "5":
                        System.Console.WriteLine("So long and thanks for all the fish!");
                        Environment.Exit(0);
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }
            } while (!userInput.Equals("5"));
        }
    }
}