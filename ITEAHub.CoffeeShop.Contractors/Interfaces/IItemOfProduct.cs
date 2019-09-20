using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    /// <summary>
    /// Interface of CoffeeShop objects like products, orders, clients etc., which we save in files
    /// </summary>
    interface IItemOfProducts
    {
        /// <summary>
        /// Unique identificator of object; we will can get object from file by ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Name of object; we will can get object from file by name
        /// </summary>
        string Name { get; set; }
    }
}
