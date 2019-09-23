using ITEAHub.CoffeeShop.BusinessLogic.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic
{
    public class Run
    {
        private readonly IMenu menu;
        private readonly ICashRegister cashRegister;
        public Run()
        {
            // How to work with branches
            // Clone a project from github
            // your current branch will be master
            // you have to create a new branch
            // right click -> new local branch from -> master
            // implementing 
            // commit 
            // check out to master branch
            // make a pull
            // check out back to your branch
            // merge in your branch from master
            // and then check out to master 
            // and make again merge to master from your branch
            // push to server on github

            //cashRegister = new //
            // menu = null2;
            // Create another objects

            //Some comment 2

            //SomeCommenst
        }
        public void Start()
        {
            List<Bonus> Bon = new List<Bonus>
            {
               new Bonus { ID = 454646, Sum =1000},
               new Bonus { ID = 223554, Sum=0},
               new Bonus { ID = 676868, Sum=50}
            };
            var St = new Store();
            if (St.Products.IsItem(1)) { Console.WriteLine("dfdfdfd"); }

            foreach (var item in Bon)
            {
                St.Bonuses.AddItem(item);

            }

            var cust = new Order();
            cust.ID = 24223;
            cust.Customer = new Customer();
            cust.Customer.ID = 1234;
            cust.Customer.Name = "John";
            cust.Customer.Surname = "Smith";
            cust.Product = new List<IProduct>
            {
                new Product { ID = 1, Name = "ffff", Amount = 10, Price = 21 },
                new Product { ID = 2, Name = "dfgdfg", Amount = 5, Price = 5 },
            };
            cust.Cash = 3434;
            St.Orders.AddItem(cust);
            var pr = St.Products.GetAll();
            foreach (var item in pr)
            {
                Console.WriteLine(item.Name);
            }

            St.Products.ChangeAmount(1, 100);



        }

        private List<IItemOfMenu> PrepareMenu()
        {
            return new List<IItemOfMenu>();
        }
    }
}
