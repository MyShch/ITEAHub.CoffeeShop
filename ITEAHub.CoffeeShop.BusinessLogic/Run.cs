using ITEAHub.CoffeeShop.Menu;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using ITEAHub.CoffeeShop.BusinessLogic.ItemsOfMenu;

namespace ITEAHub.CoffeeShop.BusinessLogic
{
    public class Run
    {
        private readonly IMenu _menu;
        
        public Run()
        {
            _menu = new GenMenu();
        }
        public void Start()
        {
            Store CurrentStore = new Store();
            _menu.Start(PrepareMenu(CurrentStore));
        }

        private List<IItemOfMenu> PrepareMenu(Store currentStore)
        {
            return new List<IItemOfMenu>(){ new BuyProduct(currentStore), new Settings(currentStore) };
        }
    }
}
