using System;
using System.Collections.Generic;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Product : IProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        
    }
}
