using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Storage.Models;
using System;
using System.Collections.Generic;

namespace ITEAHub.CoffeeShop.Storage
{
    public class Store 
    {
        public ProductStore Products = new ProductStore("Products.txt");
        public OrderStore Orders=  new OrderStore("Orders.txt");
        public CustomerStore Clients = new CustomerStore("Clients.txt");
        public BonusStorage Bonuses = new BonusStorage("Bonus.txt");
        public CashStore CashSt = new CashStore("Cash.txt");
    }
}
