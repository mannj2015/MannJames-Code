using System;
using StoreDB.Models;
using StoreLib;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreUI.Menus.Customer
{
    public class ChangeLocationMenu : IMenu
    {
        private string userInput;
        private User loggedInUser;

        private ICartRepo cartRepo;
        private ICartItemRepo cartItemRepo;
        private ILocationRepo locationRepo;
        private IUserRepo userRepo;

        private CartService cartService;
        private CartItemService cartItemService;
        private LocationService locationService;
        private UserService userService;

        public ChangeLocationMenu
            (User user, StoreContext storeContext, ICartRepo cartRepo,
            ICartItemRepo cartItemRepo, ILocationRepo locationRepo,IUserRepo userRepo)
        {
            this.loggedInUser = user;
            this.cartRepo = cartRepo;
            this.cartItemRepo = cartItemRepo;
            this.locationRepo = locationRepo;
            this.userRepo = userRepo;

            this.cartService = new CartService(cartRepo);
            this.cartItemService = new CartItemService(cartItemRepo);
            this.locationService = new LocationService(locationRepo);
            this.userService = new UserService(userRepo);
        }
        public void Start()
        {
            do
            {
                Console.WriteLine("\nSelect your preferred location: ");
                List<Location> locations = locationService.GetAllLocations();
                foreach (Location location in locations)
                {
                    Console.WriteLine($" [{location.LocationId}] {location.StreetNumber} " +
                        $"{location.Street} {location.City} {location.State} {location.ZipCode} ");
                }
                Console.WriteLine("[3] Back");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        UpdateUserLocation(1);
                        break;
                    case "2":
                        UpdateUserLocation(2);
                        break;
                    case "3":
                        break;
                    default:
                        ValidationService.InvalidInput();
                        break;
                }
            } while (!userInput.Equals("3"));

        }
        public void UpdateUserLocation(int id)
        {
            loggedInUser.LocationId = id;
            userService.UpdateUser(loggedInUser);

            Cart cart = cartService.GetCartByUserId(loggedInUser.UserId);
            cartService.DeleteCart(cart);

            Cart newCart = new Cart();
            newCart.UserId = loggedInUser.UserId;
            cartService.AddCart(newCart);

            Console.WriteLine("Location updated!\n");
        }
    }
}