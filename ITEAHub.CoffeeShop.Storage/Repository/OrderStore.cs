using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;


namespace ITEAHub.CoffeeShop.Storage.Repository
{
    public class OrderStore: IBaseRepository <Order>
    {
        public  string _path { get; }
        public OrderStore(string path)
        {
            
            this._path = path;

        }

        public  bool IsItem(int id)
        {
            bool result = false;
            List<Order> temp_result = new List<Order>();
            using (StreamReader sr = new StreamReader(_path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Order>>(json);
                    if (temp_result[0].ID == id) { result = true; }
                }
            }
            return result;
        }
        public List<Order> GetAll()
        {

            List<Order> result = new List<Order>();
            using (StreamReader sr = new StreamReader(_path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Order>>(json);
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
        public  Order GetItem(string name)
        {
            Order result = new Order();
            List<Order> temp_result = new List<Order>();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(_path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Order>>(json);
                    var res = temp_result[0].ID;
                    if (res == 0)
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
        public Order GetItem(int id)
        {
            Order result = new Order();
            List<Order> temp_result = new List<Order>();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this._path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Order>>(json);
                    if (temp_result[0].ID == id)
                    {
                        result = temp_result[0];
                        IsItem = true;
                    }

                }
            }
            if (IsItem) { return result; } else { return null; }
        }

        public void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(Order product)
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

        public bool Change(Order newItem)
        {
            throw new NotImplementedException();
        }
    }
}
