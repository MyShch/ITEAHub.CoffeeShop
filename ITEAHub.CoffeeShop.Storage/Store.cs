
using ITEAHub.CoffeeShop.Storage.Repository;
using System;


namespace ITEAHub.CoffeeShop.Storage
{
    public class Store 
    {
        public ProductStore Products = new ProductStore("D:\\Products.txt");
        public OrderStore Orders=  new OrderStore("D:\\Orders.txt");
        public CustomerStore Clients = new CustomerStore("D:\\Clients.txt");
        public BonusStorage Bonuses = new BonusStorage("D:\\Bonus.txt");
        public CashStore CashRegister = new CashStore("D:\\Cash.txt");
        
    }
}
