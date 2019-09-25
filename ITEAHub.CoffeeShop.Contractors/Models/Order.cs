using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Order : BaseEntity
    {
        //public int ID { get; set; }
       

        public Customer Customer { get; set; }
        public List<Product> Product { get; set; }

        public int Cash { get; set; }

    }
}
