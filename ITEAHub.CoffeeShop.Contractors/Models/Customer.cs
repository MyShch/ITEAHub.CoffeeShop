using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Customer : BaseEntity
    {
       // public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        
    }
}
