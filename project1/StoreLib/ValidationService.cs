using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StoreDB.Models;

namespace StoreLib
{
    public class ValidationService
    {
        public static void InvalidInput()
        {
            Console.WriteLine("Invalid selection. Please choose a valid option.");
        }

        public static void InvalidUsername()
        {
            Console.WriteLine("Incorrect username entered.");
            Console.WriteLine("Please verify your credentials and try again.");
        }

        public static void InvalidPassword()
        {
            Console.WriteLine("Incorrect password entered.");
            Console.WriteLine("Please verify your credentials and try again.");
        }

        public static Boolean ValidName(string name)
        {
            if (Regex.IsMatch(name, "[\\d]", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("Not a valid name.");
                Console.WriteLine("Your name should not have numbers.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean ValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[a-z0-9.]+@[a-z0-9]+[\.][a-z]", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Email is not valid.");
                return false;
            }
        }

        public static Boolean ValidUsername(string username, List<User> users)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("This username is already being used.");
                    return false;
                }
            }
            return true;
        }

        public static Boolean InvalidQuantity(int locQuantity, int userQuantity)
        {
            if (userQuantity > locQuantity)
            {
                Console.WriteLine("Sorry. We are out of the product at this location.");
                Console.WriteLine($"Please select no more than {locQuantity}");
                return false;
            }

            return true;
        }

    }
}