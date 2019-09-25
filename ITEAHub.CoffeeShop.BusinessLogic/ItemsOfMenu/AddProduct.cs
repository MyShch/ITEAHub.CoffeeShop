using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic.ItemsOfMenu
{
    class AddProduct : IItemOfMenu
    {
        public string Name { get { return "Add new product"; } }
        private Store _store { get; }

        public AddProduct(Store store)
        {
            _store = store;
        }

        public void Run()
        {
            
        }
    }
}
