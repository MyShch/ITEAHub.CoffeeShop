using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{/// <summary>
/// Gives some operations with storages
/// </summary>
/// <typeparam name="T">See Contractors.Models</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Return list of all entities in corresponding storage
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// Return object form storage by id (see BaseEntity)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetItem(int id);
        /// <summary>
        /// Replace corresponding item in storage by newItem, returns false if there is no such item
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        bool Change(T newItem);
        /// <summary>
        /// Remove item from storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void RemoveItem(int id);
        /// <summary>
        /// Add new item to storage; returns false item with corresponding id already exist
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AddItem(T item);
        /// <summary>
        /// true if exists item with given id in corresponding repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsItem(int id);
    }
}
