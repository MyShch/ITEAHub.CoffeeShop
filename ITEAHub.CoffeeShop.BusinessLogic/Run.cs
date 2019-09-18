using ITEAHub.CoffeeShop.BusinessLogic.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Interfaces;
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
        }
        public void Start()
        {
            var items = PrepareMenu();
            /// 

            menu.Start(items);
        }

        private List<IItemOfMenu> PrepareMenu()
        {
            return new List<IItemOfMenu>();
        }
    }
}
