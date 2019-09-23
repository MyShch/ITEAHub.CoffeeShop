using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    public interface IStorage
    {
               
        bool AddItem(IItemOfProduct product); 

        bool IsItem(int itemID);
         

    }
}
