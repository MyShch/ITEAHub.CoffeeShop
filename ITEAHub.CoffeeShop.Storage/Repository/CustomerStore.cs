using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using Newtonsoft.Json;

namespace ITEAHub.CoffeeShop.Storage.Repository
{
    public class CustomerStore: IBaseRepository <Customer>
    {

        private  string _path { get; }
        public CustomerStore(string path)
        {
            
            this._path = path;

        }

        public bool IsItem(int id)
        {
            bool result = false;
            using (StreamReader sr = new StreamReader(_path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Product>>(json);
                    if (temp_result[0].ID == id) { result = true; }
                }
            }
            return result;
        }
        public  List<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();
            using (StreamReader sr = new StreamReader(_path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Customer>>(json);
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
        public Customer GetItem(string name)
        {
            Customer result = new Customer();
           
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this._path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Customer>>(json);
                    var res = String.Compare(temp_result[0].Name, name);
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
        /// Return customer with corresponding id, return null if there is no such instance
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer GetItem(int id)
        {
            Customer result = new Customer();
            
            bool IsItem = false;
            using (StreamReader sr = new StreamReader(this._path))
            {
                string json;
                while ((json = sr.ReadLine()) != null)
                {
                    var temp_result = JsonConvert.DeserializeObject<List<Customer>>(json);
                    if (temp_result[0].ID == id)
                    {
                        result = temp_result[0];
                        IsItem = true;
                    }

                }
            }
            if (IsItem) { return result; } else { return null; }
        }

        public Customer GetItem(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(Customer product)
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

        public bool Change(Customer newItem)
        {
            throw new NotImplementedException();
        }

    }
}
