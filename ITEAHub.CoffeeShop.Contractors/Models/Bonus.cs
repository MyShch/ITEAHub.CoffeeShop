using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Bonus: IBonus
    {
        public int ID { get; set; }
        public int Sum { get; set; }
        
    }
}
