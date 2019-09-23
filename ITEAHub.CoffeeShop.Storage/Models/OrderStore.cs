﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage.Interfaces;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public class OrderStore: IOrderStorage
    {
        public  string Path { get; }
        public OrderStore(string path)
        {
            
            this.Path = path;

        }

        public  bool IsItem(int id)
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
        public List<IOrder> GetAll()
        {

            List<IOrder> result = new List<IOrder>();
            List<Order> temp_result = new List<Order>();

            using (StreamReader sr = new StreamReader(this.Path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    temp_result = JsonConvert.DeserializeObject<List<Order>>(json);
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
        public  IOrder GetItem(string name)
        {
            IOrder result = new Order();
            List<Order> temp_result = new List<Order>();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this.Path))
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
        public IOrder GetItem(int id)
        {
            IOrder result = new Order();
            List<Order> temp_result = new List<Order>();
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this.Path))
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