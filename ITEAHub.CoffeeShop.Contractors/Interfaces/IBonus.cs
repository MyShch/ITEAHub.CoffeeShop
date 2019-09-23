using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface IBonus: IItemOfProduct
    {
        int Sum { get; set; }
    }
}
