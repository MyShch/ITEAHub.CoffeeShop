using ITEAHub.CoffeeShop.Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public class CashStore : ICashStorage
    {
        private string Path;

        public CashStore(string path)
        {
            Path = path;
        }
        public int GetCash()
        {
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string temp;
                if ((temp = sr.ReadLine()) != null)
                {
                    return int.Parse(temp);
                }
                else { return 0; }
            }
        }

        public void PutCash()
        {
            int temp_cash = 0;
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string temp;
                if ((temp = sr.ReadLine()) != null)
                {
                    temp_cash = int.Parse(temp);
                }
                
            }
            using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
            {
                sw.Write(temp_cash);
            }
        }
    }
}
