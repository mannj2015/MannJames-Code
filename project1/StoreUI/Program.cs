using StoreDB;
using StoreUI.Menus;
using Serilog;
using StoreDB.Models;

namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreContext context = new StoreContext();
            IMenu mainMenu = new MainMenu(context, new DBRepo(context), new DBRepo(context), new DBRepo(context));
            mainMenu.Start();
        }
    }
}
