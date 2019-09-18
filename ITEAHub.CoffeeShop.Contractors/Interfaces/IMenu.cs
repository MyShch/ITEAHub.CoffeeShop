using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface IMenu
    {
        void Start(List<IItemOfMenu> itemOfMenus);
    }
}
