using System;
using Serilog;
using System.Collections.Generic;
using StoreLib;
using StoreDB;
using StoreDB.Models;
using StoreDB.Repos;
using StoreUI.Menus.Customer;
using StoreUI.Menus.Manager;

namespace StoreUI.Menus
{
    public class MainMenu : IMenu
    {
        private string userInput;
        private User signedInUser;
        private StoreContext context;

        private ICartRepo cartRepo;
        private ILocationRepo locationRepo;
        private IUserRepo userRepo;

        private CartService cartService;
        private LocationService locationService;
        private UserService userService;

        private CustomerMenu customerMenu;
        private ManagerMenu managerMenu;

        public MainMenu(StoreContext context, IUserRepo userRepo, ILocationRepo locationRepo, 
            ICartRepo cartRepo)
        {
            this.context = context;
            this.userRepo = userRepo;
            this.locationRepo = locationRepo;
            this.cartRepo = cartRepo;

            this.userService = new UserService(userRepo);
            this.locationService = new LocationService(locationRepo);
            this.cartService = new CartService(cartRepo);
        }


        public void Start()
        {
            do
            {
                Console.WriteLine("\nWelcome to Mann's Videogame Shoppe!");
                Console.WriteLine("Please select an option numbered below: ");

                //Welcome Menu options
                Console.WriteLine("[1] Sign In");
                Console.WriteLine("[2] Sign Up");
                Console.WriteLine("[3] Exit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        User user = SignIn();
                        break;

                    case "2":
                        User newUser = GetNewUserDetails();
                        userService.AddUser(newUser);
                        break;

                    case "3":
                        Console.WriteLine("So long! Farewell!");
                        Environment.Exit(0);
                        break;

                    default:
                        ValidationService.InvalidInput();
                        break;
                }

            } while (!userInput.Equals("3"));
        }

        public User SignIn()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs\\LoginAttempts.txt")
            .CreateLogger();

            string username;
            string password;
            User user = new User();

            Console.WriteLine("\nEnter username: ");
            username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            password = Console.ReadLine();

            try
            {
                user = userService.GetUserByUsername(username);
                if (user.Password != password)
                {
                    throw new System.ArgumentException();
                }
                else
                {
                    signedInUser = user;

                    //Log the sign in 
                    Log.Information($"User {signedInUser.Username} signed in successfully");

                    if (user.Type == User.UserType.Manager)
                    {
                        managerMenu = new ManagerMenu(signedInUser, context, new DBRepo(context), new DBRepo(context));
                        managerMenu.Start();
                    }

                    if (user.Type == User.UserType.Customer)
                    {
                        customerMenu = new CustomerMenu(signedInUser, context);

                        //Deletes existing cart
                        try
                        {
                            cartService.DeleteCart(cartService.GetCartByUserId(signedInUser.UserId));
                        }
                        catch (InvalidOperationException) { }
                        finally
                        {
                            //Creates new cart for customer user
                            Cart newCart = new Cart();
                            newCart.UserId = signedInUser.UserId;
                            cartService.AddCart(newCart);

                            customerMenu.Start();
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                //Log the sign in attempt
                Log.Information($"User {user.Username} attempted to sign in unsuccessfully");
                ValidationService.InvalidPassword();
            }
            catch (InvalidOperationException)
            {
                //Log the sign in attempt
                Log.Information($"A user has attempted to sign in to an account that does not exist " +
                    $"using username: {username} ");
                ValidationService.InvalidUsername();
            }
            return user;
        }

        public User GetNewUserDetails()
        {
            List<User> users = userService.GetAllUsers();
            User user = new User();
            user.Type = User.UserType.Customer;
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
                    Console.WriteLine($" [{loc.LocationId}] {loc.City} {loc.State} {loc.ZipCode}");
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
            Console.WriteLine("Account created! Thanks for signing up!");
            return user;
        }
    }
}