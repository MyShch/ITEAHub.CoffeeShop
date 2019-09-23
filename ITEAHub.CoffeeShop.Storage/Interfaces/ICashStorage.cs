using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Interfaces
{
    public interface ICashStorage
    {
        int GetCash();

        void PutCash();

    }
}
