using ShopDatabaseAdvanced.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask client's name and greet him or her by name
            Console.WriteLine("Your fullname please: ");
            string fullName = Console.ReadLine();
            string[] separator = { " " };
            string[] name = fullName.Split(separator,2, StringSplitOptions.RemoveEmptyEntries);
            string firstName = name[0];
            string lastName = name[1];

            Console.Clear();
            Console.WriteLine($"Hello {ToFirstUpper(firstName)}!");
            Console.WriteLine("Please wait...");

            using (ShopDbContext db = new ShopDbContext())
            {

                DbQuery<Customer> customersFromDb = db.Customers;

                //Determine if this client exists in the database
                Customer currentCustomer;
                Customer customerInDatabase = (customersFromDb.FirstOrDefault(customer => customer.FirstName == firstName && customer.LastName == lastName));
                bool isNewCustomer;

                if (customerInDatabase==null)
                {
                    //If client doesn't exist, add him or her to the database
                    isNewCustomer = true;
                    //Console.WriteLine("customer is not in database");
                    currentCustomer = new Customer();
                    currentCustomer.FirstName = firstName;
                    currentCustomer.LastName = lastName;

                }
                else
                {
                    isNewCustomer = false;
                    //Console.WriteLine("customer is in database");
                    currentCustomer = customerInDatabase;
                }
                //Console.WriteLine(currentCustomer.FirstName+" "+currentCustomer.LastName);

                //Create a new Shopping Cart and let your client do the shopping.
                ShoppingCart newShoppingCart = new ShoppingCart();
                currentCustomer.ShoppingCarts.Add(newShoppingCart);
                if (isNewCustomer)
                    db.Customers.Add(currentCustomer);
                db.SaveChanges();
                Console.Clear();

                DbQuery<Food> FoodsFromDb = db.Foods;
                do
                {
                    ChooseFood(FoodsFromDb, newShoppingCart);
                }
                while (Console.ReadLine().ToLower() == "y");
                db.SaveChanges();

                //Show the contents of the current shopping cart together with the its total price.
                Console.Clear();
                Console.WriteLine("Your current shopping cart:");
                foreach (Food food in newShoppingCart.Foods)
                {
                    Console.WriteLine(food.Name);
                }
                Console.WriteLine("Total Sum: " + newShoppingCart.Sum);
                Console.WriteLine("----------------------------------");

                //Determine, how many times your current client has visited the shop

                int shoppingCount = db.ShoppingCarts.Where(cart => cart.Customer.CustomerId == currentCustomer.CustomerId).Count();
                if (shoppingCount == 1)
                    Console.WriteLine("This is Your first visit!");
                else
                {
                    Console.WriteLine("Your Total visits: " + shoppingCount);
                    //Ask him/her, if he/she wants to see his/her shopping history
                    Console.WriteLine("Do You like to see Your shopping history? y/n");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        DbQuery<ShoppingCart> ShopingCartsWithFoodFromDb = db.ShoppingCarts.Include("Foods");

                        List<ShoppingCart> CurrentCustomersShoppingCarts = ShopingCartsWithFoodFromDb.Where(cart => cart.Customer.CustomerId == currentCustomer.CustomerId).OrderByDescending(cart => cart.DateCreated).ToList();
                        Console.Clear();
                        foreach (ShoppingCart cart in CurrentCustomersShoppingCarts)
                        {
                            Console.WriteLine(cart.DateCreated);
                            foreach (Food food in cart.Foods)
                            {
                                Console.WriteLine(food.Name);
                            }
                            Console.WriteLine("Total Sum: "+cart.Sum);
                            Console.WriteLine("----------------------------------");
                        }

                    }
                }
                //Thank your client for visiting and wish him or her a nice day!
                Console.WriteLine($"Thank You for Visiting {firstName}, have a nice day!");

                //all shoping history
                //DbQuery<ShoppingCart> ShopingCartsWithFoodFromDb = db.ShoppingCarts.Include("Foods");

                //Console.WriteLine("-----------------");
                //foreach (ShoppingCart cart in ShopingCartsWithFoodFromDb)
                //{
                //    Console.WriteLine(cart.DateCreated);
                //    foreach (Food food in cart.Foods)
                //    {
                //        if (food!=null) Console.WriteLine(food.Name);
                //    }

                //}




            }


            Console.ReadLine();

        }

        private static void ChooseFood(DbQuery<Food> foodsFromDb, ShoppingCart newShoppingCart)
        {
            Console.WriteLine("What do you want to buy? ");
            string foodName = Console.ReadLine().ToLower();
            Food chosenFood = foodsFromDb.FirstOrDefault(x => x.Name == foodName);
            if (chosenFood!=null)
                newShoppingCart.AddToCard(chosenFood);
            else
                Console.WriteLine("We don't have this!");
            Console.WriteLine("Anything else? y/n");
        }

        private static string ToFirstUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
