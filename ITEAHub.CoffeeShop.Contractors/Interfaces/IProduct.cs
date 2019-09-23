using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface IProduct: IItemOfProduct
    {
        string Name { get; set; }

        double Price { get; set; }

        int Amount { get; set; }
    }
}
