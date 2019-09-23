using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    public interface IProductStorage:IStorage
    {
        List<IProduct> GetAll();

        IProduct GetItem(int id);

        IProduct GetItem(string name);

        bool ChangeAmount(int id, int sum);

        bool RemoveItem(int id);

    }
}
