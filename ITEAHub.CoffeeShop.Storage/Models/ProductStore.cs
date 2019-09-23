using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public class ProductStore : IProductStorage
    {

        private string Path { get; }
        
        public ProductStore(string path)
        {
            this.Path= path;
        }

        public bool IsItem(int id)
        {
            bool result = false;
            List<Product> temp_result = new List<Product>();
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Product>>(json);
                    if (temp_result[0].ID == id) { result = true; }
                }
            }
            return result;
        }
       
        public List<IProduct> GetAll()
        {
            List<IProduct> result = new List<IProduct>();
            List<Product> temp_result = new List<Product>();

            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Product>>(json);
                    result.Add(temp_result[0]);
                }
            }
            

            return result;

        }
        /// <summary>
        /// Return product with corresponding name, return null if there is no such instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public  IProduct GetItem(string name)
        {
            IProduct result = new Product();
            List<Product> temp_result = new List<Product>();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Product>>(json);
                    var res = String.Compare(temp_result[0].Name, name);
                    if (res==0)
                    {
                        result = temp_result[0];
                        IsItem = true;
                    }
                    
                }
            }
            if (IsItem) { return result; } else { return null; }
        }
        /// <summary>
        /// Return product with corresponding name, return null if there is no such instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IProduct GetItem(int id)
        {
            IProduct result = new Product();
            
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Product>>(json);
                    if (temp_result[0].ID==id)
                    {
                        result = temp_result[0];
                        IsItem = true;
                    }

                }
            }
            if (IsItem) { return result; } else { return null; }
        }

        public bool ChangeAmount(int id, int sum)
        {

            List<IProduct> templist = new List<IProduct>();
            bool isrec = IsItem(id);
            if (isrec)
            {
                using (StreamReader sr = new StreamReader(this.Path))
                {
                    string json;
                    while ((json = sr.ReadLine()) != null)
                    {
                        var tempbonus = JsonConvert.DeserializeObject<List<Product>>(json);

                        if (tempbonus[0].ID == id)
                        {
                            tempbonus[0].Amount += sum;
                            templist.Add(tempbonus[0]);
                        }
                        else { templist.Add(tempbonus[0]); }
                    }
                }
                using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
                {
                    foreach (var item in templist)
                    {
                        sw.WriteLine("[" + JsonConvert.SerializeObject(item) + "]");
                    }


                }
            }
            return isrec;
        }

        public bool RemoveItem(int id)
        {
            throw new NotImplementedException();
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
    }
}
