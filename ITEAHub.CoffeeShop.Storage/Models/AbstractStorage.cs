using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public abstract class AbstractStorage : IStorage
    {
        public string Name { get; set; }

        public void AddItem(List<IItemOfProduct> products)
        {
            throw new NotImplementedException();
        }

        public List<IItemOfProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public IItemOfProduct GetItem(string name)
        {
            throw new NotImplementedException();
        }

        public IItemOfProduct GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
