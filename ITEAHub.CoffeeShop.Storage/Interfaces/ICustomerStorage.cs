using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    interface ICustomerStorage:IStorage
    {
        List<ICustomer> GetAll();

        ICustomer GetItem(int id);

        ICustomer GetItem(string name);

        ICustomer GetItem(string name, string surname);

        bool RemoveItem(int id);

    }
}
