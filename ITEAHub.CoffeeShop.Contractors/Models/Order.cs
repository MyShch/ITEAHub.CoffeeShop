using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Order : IOrder
    {
        public int ID { get; set; }
       

        public ICustomer Customer { get; set; }
        public List<IProduct> Product { get; set; }

        public int Cash { get; set; }

    }
}
