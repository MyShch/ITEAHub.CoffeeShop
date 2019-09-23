using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface IOrder:IItemOfProduct
    {
        ICustomer Customer { get; set; }
        List<IProduct> Product { get; set; }

        int Cash { get; set; }
    }
}
