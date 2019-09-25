using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Menu;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic.ItemsOfMenu
{
    public class Settings : IItemOfMenu

    {
        public string Name { get { return "Change shop settings (password required)"; } }

        private Store _store { get; }

        public Settings(Store store)
        {
            _store = store;
        }

        public void Run()
        {
            if (GetPassword())
            {
                var menu = new GenMenu();
                menu.Start(PrepareMenu(_store));
            }
            else
            {
                Console.WriteLine("Wrong password! Press any key to continue"); Console.ReadKey(); 
            }
        }

        private bool GetPassword()
        {
            Console.WriteLine("Enter password:");
            var pass = Console.ReadLine();
            if (pass == "admin") { return true; } else { return false; }
        }
        private List<IItemOfMenu> PrepareMenu(Store currentStore)
        {
            return new List<IItemOfMenu>() { new AddProduct(currentStore), new ShowAllProducts(currentStore) };
        }
    }
}
