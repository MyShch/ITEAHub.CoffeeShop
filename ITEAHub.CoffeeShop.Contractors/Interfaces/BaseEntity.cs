using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.Contractors.Interfaces
{
    /// <summary>
    /// Interface of CoffeeShop objects like products, orders, clients etc., which we save in files
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identificator of all object models; we will can get object from file by ID
        /// </summary>
        public int ID { get; set; }

       }
}
