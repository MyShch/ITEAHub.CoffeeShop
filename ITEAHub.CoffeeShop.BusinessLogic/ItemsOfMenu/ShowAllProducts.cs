using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic.ItemsOfMenu
{
    class ShowAllProducts: IItemOfMenu
    {
        public string Name { get { return "Show All Products"; } }
        private Store _store { get; }

        public ShowAllProducts(Store store)
        {
            _store = store;
        }

        public void Run()
        {
            Console.WriteLine("     Amounof all products  ");
            Console.WriteLine("{0,-6}{1,-20}{2,5}{3,9}\n", "No.", "Name", "Price", "Amount");
            var products = _store.Products.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine(" {0,-6:N0}{1,-20}{2,5:N0}{3,8:N0}\n", item.ID, item.Name, item.Price, item.Amount);
            }
            Console.ReadKey();
        }
    }
}
