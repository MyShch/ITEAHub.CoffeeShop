using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Models
{
    public class Bonus: BaseEntity
    {
        //public int ID { get; set; }
        public int Sum { get; set; }

        public static int CreateBonusCard()
        {
            var rand = new Random();
            return rand.Next(1000000, 9999999);
        }
        
    }
}
