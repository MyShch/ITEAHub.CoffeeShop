using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using Newtonsoft.Json;

namespace ITEAHub.CoffeeShop.Storage.Repository
{
    public class BonusStorage: IBaseRepository <Bonus>
    {
        private string _path;

        public BonusStorage(string path)
        {
            _path = path;
        }

        public bool AddItem(Bonus product)
        {
            var IsRec = IsItem(product.ID);
            var json = JsonConvert.SerializeObject(product);
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.Default))
            {
                if (!IsRec)
                {
                    sw.WriteLine("[" + json + "]");
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsItem(int id)
        {
           bool result = false;
           using (StreamReader sr = new StreamReader(_path))
           {
                    string json;
                    while ((json= sr.ReadLine()) != null)
                    {
                        var temp_result = JsonConvert.DeserializeObject<List<Bonus>>(json);
                        if (temp_result[0].ID == id)
                            {
                                result = true;
                            }
                    }
           }
           return result;
        }

        public bool Change(Bonus newItem)
        {
            List<Bonus> templist = new List<Bonus>();
            bool isrec = IsItem(newItem.ID);
            if (isrec)
            {
                using (StreamReader sr = new StreamReader(_path))
                {
                    string json;
                    while ((json = sr.ReadLine()) != null)
                    {
                        var tempbonus = JsonConvert.DeserializeObject<List<Bonus>>(json);
                                               
                        if (tempbonus[0].ID == newItem.ID)
                        {
                            tempbonus[0].Sum += newItem.Sum;
                            templist.Add(tempbonus[0]);
                        }
                        else
                        {
                            templist.Add(tempbonus[0]);
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(_path, false, System.Text.Encoding.Default))
                {
                    foreach (var item in templist)
                    {
                        sw.WriteLine("[" + JsonConvert.SerializeObject(item) + "]");
                    }
                } 
            }
            return isrec;
        }

        public Bonus GetItem(int id)
        {
            Bonus result = new Bonus();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this._path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Bonus>>(json);
                    if (temp_result[0].ID == id) { result = temp_result[0]; IsItem = true; }
                }
            }
            if (IsItem) { return result; } else { return null; }

        }

        public List<Bonus> GetAll()
        {
            throw new NotImplementedException();
        }

        
        public void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
