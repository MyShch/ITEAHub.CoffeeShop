using ITEAHub.CoffeeShop.BusinessLogic.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic
{
    public class Run
    {
        private readonly IMenu menu;
        private readonly ICashRegister cashRegister;
        public Run()
        {
           //cashRegister = new //
           // menu = null;
           // Create another objects
        }
        public void Start()
        {
            var items = PrepareMenu();
            /// 

            menu.Start(items);
        }

        private List<IItemOfMenu> PrepareMenu()
        {
            return new List<IItemOfMenu>();
        }
    }
}
