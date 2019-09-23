using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface ICustomer:IItemOfProduct
    {
         string Name { get; set; }

         string Surname { get; set; }
    }
}
