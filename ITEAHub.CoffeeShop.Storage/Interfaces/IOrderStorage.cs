using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    interface IOrderStorage:IStorage
    {
        List<IOrder> GetAll();

        IOrder GetItem(int id);

        IOrder GetItem(string name);


        bool RemoveItem(int id);
    }
}
