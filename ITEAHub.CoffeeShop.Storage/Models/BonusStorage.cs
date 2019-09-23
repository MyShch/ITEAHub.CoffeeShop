using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage.Interfaces;
using Newtonsoft.Json;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public class BonusStorage:IBonusStorage
    {
        private string Path;

        public BonusStorage(string path)
        {
            Path = path;
        }

        public bool AddItem(IItemOfProduct product)
        {
            var IsRec = IsItem(product.ID);
            var json = JsonConvert.SerializeObject(product);
            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
            {
                if (!IsRec) { sw.WriteLine("[" + json + "]"); return true; } else { return false; }
            }
        }

        public bool IsItem(int id)
        {
           bool result = false;
           using (StreamReader sr = new StreamReader(this.Path))
           {
                    string json;
                    while ((json= sr.ReadLine()) != null)
                    {

                        var temp_result = JsonConvert.DeserializeObject<List<Bonus>>(json);
                            
                        if (temp_result[0].ID == id) { result = true; }
                    }
           }
            

            return result;
        }

        public bool Change(int id, int sum)
        {
            List<IBonus> templist = new List<IBonus>();
            bool isrec = IsItem(id);
            if (isrec)
            {
                using (StreamReader sr = new StreamReader(this.Path))
                {
                    string json;
                    while ((json = sr.ReadLine()) != null)
                    {
                        var tempbonus = JsonConvert.DeserializeObject<List<Bonus>>(json);
                                               
                        if (tempbonus[0].ID == id)
                        {
                            tempbonus[0].Sum += sum;
                            templist.Add(tempbonus[0]);
                        }
                        else { templist.Add(tempbonus[0]); }
                    }
                }
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    foreach (var item in templist)
                    {
                        sw.WriteLine("[" + JsonConvert.SerializeObject(item) +"]");
                    }
                                               
                    
                }
            }
            return isrec;

        }

        public int GetBonus(int id)
        {
            int result = -1;
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {

                    var temp_result = JsonConvert.DeserializeObject<List<Bonus>>(json);

                    if (temp_result[0].ID == id) { result = temp_result[0].Sum; }
                }
            }
            return result;

        }
    }
}
