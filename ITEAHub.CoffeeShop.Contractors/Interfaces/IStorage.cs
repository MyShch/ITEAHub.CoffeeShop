using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    public interface IStorage
    {
        /// <summary>
        /// Contains Name of storage
        /// </summary>
         string Name { get; }

        /// <summary>
        /// Get from file list of all objects from Storage
        /// </summary>
        /// <returns>List of all objects</returns>
        List<IItemOfProduct> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IItemOfProduct GetItem(string name);

        IItemOfProduct GetItem(int id);
        
        /// <summary>
        /// Add given object to storage
        /// </summary>
        /// <param name="products"></param>
        void AddItem(List<IItemOfProduct> products);

        void RemoveItem(string name);
        

    }
}
