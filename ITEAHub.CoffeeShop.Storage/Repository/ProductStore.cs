using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITEAHub.CoffeeShop.Storage.Repository
{
    public class ProductStore : IBaseRepository<Product>

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
       
        public  List<Product> GetAll()
        {
            List<Product> result = new List<Product>();
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
        public  Product GetItem(string name)
        {
            Product result = new Product();
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
        public Product GetItem(int id)
        {
            Product result = new Product();
            
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

        public bool Change(Product newItem)
        {

            List<Product> templist = new List<Product>();
            bool isrec = IsItem(newItem.ID);
            if (isrec)
            {
                using (StreamReader sr = new StreamReader(this.Path))
                {
                    string json;
                    while ((json = sr.ReadLine()) != null)
                    {
                        var tempbonus = JsonConvert.DeserializeObject<List<Product>>(json);

                        if (tempbonus[0].ID == newItem.ID)
                        {
                            tempbonus[0].Amount = newItem.Amount;
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

        public void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(Product product)
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
