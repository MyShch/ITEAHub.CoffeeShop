using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    class OrderStore: AbstractStorage
    {
        private string _path { get; }
        public OrderStore(string name, string path)
        {
            this.Name = name;
            this._path = path;

        }
    }
}
