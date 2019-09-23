using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    interface IBonusStorage:IStorage
    {
        bool Change(int id, int sum);

        int GetBonus(int id);
    }
}
