using ITEAHub.CoffeeShop.Contractors.Interfaces;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage.Interfaces;

namespace ITEAHub.CoffeeShop.Storage.Models
{
    public abstract class AbstractStorage:IStorage
    {

        public abstract string Path { get;  }

        public abstract bool IsItem(int itemID);

        public void AddItem(IItemOfProduct products)
        {
            var json = JsonConvert.SerializeObject(products);


            using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("[" + json +"]");
            }
        }
               

        
        
    }
}
