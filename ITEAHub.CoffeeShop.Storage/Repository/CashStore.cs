using ITEAHub.CoffeeShop.Contractors.Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Repository
{
    public class CashStore : ICashStorage
    {
        private string _path;

        public CashStore(string path)
        {
            _path = path;
        }
        public int GetCash()
        {
            using (StreamReader sr = new StreamReader(this._path))
            {
                string temp;
                if ((temp = sr.ReadLine()) != null)
                {
                    return int.Parse(temp);
                }
                else
                {
                    return 0;
                }
            }
        }

        public void PutCash(int sum)
        {
            int temp_cash = 0;
            using (StreamReader sr = new StreamReader(this._path))
            {
                string temp;
                if ((temp = sr.ReadLine()) != null)
                {
                    temp_cash = int.Parse(temp);
                }
            }
            using (StreamWriter sw = new StreamWriter(_path, false, System.Text.Encoding.Default))
            {
                sw.Write(temp_cash+sum);
            }
        }
    }
}
