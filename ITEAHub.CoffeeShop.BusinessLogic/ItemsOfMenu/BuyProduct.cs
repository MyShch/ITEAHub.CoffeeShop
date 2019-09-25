using ITEAHub.CoffeeShop.Contractors.Interfaces;
using ITEAHub.CoffeeShop.Contractors.Models;
using ITEAHub.CoffeeShop.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEAHub.CoffeeShop.BusinessLogic.ItemsOfMenu
{
    public class BuyProduct : IItemOfMenu
    {
        public string Name
        { get { return "Buy some coffee"; } }

        private Store _store { get; }

        public BuyProduct(Store store)
        {
            _store = store;
        }
        /// <summary>
        /// Show order to client
        /// </summary>
        /// <param name="order"></param>
        private void ShowOrder(Order order)
        {
            Console.WriteLine("Your order");
            Console.WriteLine(" {0,-15}{1,6:N0}\n", "Order ID:", order.ID);
            Console.WriteLine(" {0,-15}{1,6}\n", "Surname:", order.Customer.Surname);
            Console.WriteLine(" {0,-15}{1,6:N0}\n", "Name:", order.Customer.Name);
            Console.WriteLine(" {0,-15}{1,6:N0}\n", "BonusCard:", order.Customer.ID);
            Console.WriteLine(" {0,-15}{1,6}\n", "Product:", order.Product[0].Name);
            Console.WriteLine(" {0,-15}{1,6:N0}\n", "Price per unit:", order.Product[0].Price);
            Console.WriteLine(" {0,-15}{1,6:N0}\n", "Total sum:", order.Cash);


           // Console.WriteLine($"Order ID: {order.ID}\nSurname: {order.Customer.Surname}\nName: {order.Customer.Name}\nBonusCard: {order.Customer.ID}\nProduct: {order.Product[0].Name}\nPrice per unit: {order.Product[0].Price}\nPaid sum: {order.Cash}");
        }
        /// <summary>
        /// Creating order for client
        /// </summary>
        /// <param name="saled"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private Order CreateOrder(Product saled, int amount)
        {
            var result = new Order() { Customer=new Customer(), Product=new List<Product>() };
            var used = UseBonusCard(saled.Price * amount);
            if (used > 0)
            {
                result.Customer = _store.Clients.GetItem(used);// add client to order when it used bonuscsrd
            }
            else
            {// registering new client
                result.Customer.ID = Bonus.CreateBonusCard();
                Console.WriteLine("Enter your name:");
                result.Customer.Name = Console.ReadLine();
                Console.WriteLine("Enter your surname:");
                result.Customer.Surname = Console.ReadLine();
                _store.Clients.AddItem(result.Customer);
                _store.Bonuses.AddItem(new Bonus() { ID = result.Customer.ID, Sum = saled.Price * amount });
                Console.WriteLine($"Dear {result.Customer.Name} {result.Customer.Surname} we give BonusCard N {result.Customer.ID}");
                Console.WriteLine($"For now it contains {saled.Price * amount }$ bonuses");
            }
                       
            result.ID= Bonus.CreateBonusCard();
            result.Product.Add(saled);
            result.Cash = saled.Price * amount;
            ShowOrder(result);
            return result;
        }
        /// <summary>
        /// Using BonusCard during payment, returns its id (and client id at the same time). If customer haven't it return -1
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        private int UseBonusCard(int sum)
        {
            Console.WriteLine("If you have BonusCard enter it number(7 integers), else type 'n':");
            var temp = Console.ReadLine();
            int id = 0;
            int.TryParse(temp, out id);
            var bonus = _store.Bonuses.GetItem(id);
            if (bonus != null)
            {
                Console.WriteLine($"Your have {bonus.Sum}$ of bonuses. Wish you pay using bonuses?(y/n)");
                var choice = Console.ReadLine();
                if (choice == "y")
                {
                    if (bonus.Sum >= sum)
                    {
                        bonus.Sum -= sum;
                        Console.WriteLine($"Payment was successfull! Rest is {bonus.Sum}$ of bonuses");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough bonuses. You must pay {sum - bonus.Sum}$ by cash");
                        bonus.Sum = 0;
                    }

                }
                else
                {
                    bonus.Sum += sum;
                }
                return id;

            }
            else
            {
                Console.WriteLine("Sorry, you don't have BonusCard!\nRegister and get it.");
                return -1;
            }


        }

        public void Run()
        {
            var products = _store.Products.GetAll();

            ShowMenu(products);

            Sell(products);
            
        }
        /// <summary>
        /// Show menu for the customer
        /// </summary>
        /// <param name="products"></param>
        private void ShowMenu(List<Product> products)
        {
            Console.WriteLine("           MENU");
            Console.WriteLine("{0,-6}{1,-20}{2,5}\n", "No.", "Name", "Price");
            foreach (var item in products)
            {
                Console.WriteLine(" {0,-6:N0}{1,-20}{2,4:N0}\n", item.ID, item.Name, item.Price);
            }
        }

        /// <summary>
        /// Sell products
        /// </summary>
        /// <param name="products"></param>
        private void Sell(List<Product> products)
        {
            var choice_id = GetChoice();//Customer choose what to buy

            if (_store.Products.GetItem(choice_id) != null)// true if such item exists
            {
                int amount = products[choice_id - 1].Amount;
                int quantity = GetQuantity(products[choice_id - 1].Name);//Custormer shoose how much fo products he wants to buy
                if ((amount - quantity) >= 0)
                {
                    var sum = quantity * products[choice_id - 1].Price;
                    GetPayment(sum, quantity, products[choice_id - 1]);// get payment, showing order and put change storages
                }
                else { Console.WriteLine("We are sorry product you choose ended. Take another variant"); }
            }
            else { Console.WriteLine("Uncorrect choice. Take another variant"); }
            Console.ReadKey();
        }
        /// <summary>
        /// Making payment (cashregister)
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="quantity"></param>
        /// <param name="product"></param>
        private void GetPayment(int sum, int quantity, Product product)
        {
            Console.WriteLine($"You must pay {sum}$. Pay (y/n)?");
            var paid = Console.ReadLine();
            if (paid == "y")
            {
                _store.CashRegister.PutCash(sum);
                product.Amount -= quantity;
                _store.Products.Change(product);
                _store.Orders.AddItem(CreateOrder(product, quantity));// creating order
                Console.WriteLine("Thank you for your choice! See you later. Press any key to return main menu.");
            }
            else { Console.WriteLine("Thanks. See you later. Press any key to return main menu."); }
        }

        private int GetChoice()
        {
            int result = 0;
            Console.WriteLine("Choose an option:");
            var choice = Console.ReadLine();
            int.TryParse(choice, out result);
            return result;
        }

        private int GetQuantity(string name)
        {
            int result = 0;
            Console.WriteLine($"How many of {name}s you want to buy?");
            var choice = Console.ReadLine();
            int.TryParse(choice, out result);
            return result;
        }


    }
}
