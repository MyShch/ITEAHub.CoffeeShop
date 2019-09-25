using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface ICashStorage
    {
        int GetCash();

        void PutCash(int sum);

    }
}
