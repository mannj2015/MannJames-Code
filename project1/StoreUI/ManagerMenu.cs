using System;
using StoreDB;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.Manager
{
    public class ManagerMenu : IMenu
    {
        private string userInput;
        private User loggedInUser;
        private IUserRepo userRepo;
        private UserService userService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private EditInventoryMenu editInvMenu;

        public ManagerMenu(User user, StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo)
        {
            this.loggedInUser = user;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);

            this.editInvMenu = new EditInventoryMenu
                (loggedInUser, context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
        }

        public void Start()
        {
            do
            {
                Console.WriteLine($"\nWelcome {loggedInUser.Name}!"); 
                Console.WriteLine("What would you like to do today?");

                //Manager Menu Options
                System.Console.WriteLine("[1] Manage Inventory");
                System.Console.WriteLine("[2] Create Manager User");
                System.Console.WriteLine("[3] Exit");

                userInput = System.Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        editInvMenu.Start();
                        break;
                    case "2":
                        User newUser = GetNewManagerDetails();
                        userService.AddUser(newUser);
                        break;
                    case "3":
                        System.Console.WriteLine("Adieu!");
                        Environment.Exit(0);
                        break;
                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while (!userInput.Equals("3"));
        }

        public User GetNewManagerDetails()
        {
            List<User> users = userService.GetAllUsers();
            User user = new User();
            user.Type = User.UserType.Manager;
            string selectedLocation;

            do
            {
                Console.WriteLine("\nEnter name: ");
                user.Name = Console.ReadLine();
            } while (ValidationService.ValidName(user.Name) == false);

            do
            {
                Console.WriteLine("Enter email: ");
                user.Email = Console.ReadLine();
            } while (ValidationService.ValidEmail(user.Email) == false);

            do
            {
                Console.WriteLine("Create a username: ");
                user.Username = Console.ReadLine();
            } while (ValidationService.ValidUsername(user.Username, users) == false);

            Console.WriteLine("Create a password: ");
            user.Password = Console.ReadLine();

            Console.WriteLine("Select preferred location: ");
            Boolean invalidSelection = true;
            do
            {
                List<Location> locs = locationService.GetAllLocations();
                foreach (Location loc in locs)
                {
                    Console.WriteLine($" [{loc.LocationId}] {loc.City} {loc.State}");
                }

                selectedLocation = Console.ReadLine();
                switch (selectedLocation)
                {
                    case "1":
                        user.LocationId = 1;
                        invalidSelection = false;
                        break;

                    case "2":
                        user.LocationId = 2;
                        invalidSelection = false;
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }
            } while (invalidSelection);

            Console.WriteLine("Created user account! Welcome!");
            return user;
        }
    }
}