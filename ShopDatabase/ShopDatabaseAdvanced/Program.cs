using ShopDatabaseAdvanced.models;
using ShopDatabaseAdvanced.ShopDatabaseAdvanced;
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
            //List<Food> groceries = new List<Food>
            //{
            //new Food("apple", 1.7),
            //new Food("bread", 1.2),
            //new Food("cheese", 2),
            //new Food("milk",1),
            //new Food("icecream",1.5)
            //};

            //Ask client's name and greet him or her by name
            Console.WriteLine("Your fullname please: ");
            string fullName = Console.ReadLine();
            string[] separator = { " " };
            string[] name = fullName.Split(separator,2, StringSplitOptions.RemoveEmptyEntries);
            string firstName = name[0];
            string lastName = name[1];
            
            Console.WriteLine($"Hello {ToFirstUpper(firstName)}!");

            using (ShopDbContext db = new ShopDbContext())
            {

                DbQuery<Customer> customersFromDb = db.Customers;
                
                

                //List<Customer> allCustomers = customersFromDb.ToList();


                //Determine if this client exists in the database
                Customer currentCustomer;
                Customer customerInDatabase = (customersFromDb.FirstOrDefault(customer => customer.FirstName == firstName && customer.LastName == lastName));
                bool isNewCustomer;

                if (customerInDatabase==null)
                {
                    isNewCustomer = true;
                    Console.WriteLine("customer is not in database");
                    currentCustomer = new Customer();
                    currentCustomer.FirstName = firstName;
                    currentCustomer.LastName = lastName;

                }
                else
                {
                    isNewCustomer = false;
                    Console.WriteLine("customer is in database");
                    currentCustomer = customerInDatabase;
                }
                Console.WriteLine(currentCustomer.FirstName+" "+currentCustomer.LastName);

                ShoppingCart newShoppingCart = new ShoppingCart();
                currentCustomer.ShoppingCarts.Add(newShoppingCart);
                if (isNewCustomer)
                    db.Customers.Add(currentCustomer);
                db.SaveChanges();

                //Food food = new Food("apple", 1.7);

                //newShoppingCart.Foods.Add(food);
                //db.SaveChanges();


                DbQuery<Food> FoodsFromDb = db.Foods;

                if (FoodsFromDb.Count() == 0)
                {
                    List<Food> listOfFoods = new List<Food>
                    {
                    new Food("apple", 1.7),
                    new Food("bread", 1.2),
                    new Food("cheese", 2),
                    new Food("milk",1),
                    new Food("icecream",1.5)
                    };

                    db.Foods.AddRange(listOfFoods);
                    db.SaveChanges();
                }


                //foreach (Customer customer in allCustomers)
                //{

                //    if (customer.LastName==lastName && customer.FirstName==firstName)
                //    {
                //        isCustomerInDatabase = true;
                //        Console.WriteLine("Welcome Back!");
                //        break;
                //    } 
                //}

                //if(!isCustomerInDatabase)
                //{
                //    Customer newCustomer = new Customer();
                //    newCustomer.FirstName = firstName;
                //    newCustomer.LastName = lastName;

                //    ShoppingCart newShoppingCart = new ShoppingCart();

                //    newCustomer.ShoppingCarts.Add(newShoppingCart);
                //    db.Customers.Add(newCustomer);
                //    db.SaveChanges();


                //}
                //------------------

                //Create a new Shopping Cart and let your client do the shopping.

                //db.ShoppingCarts.Add(newShoppingCart);

                //db.SaveChanges();

                //do
                //{
                //   // ChooseFood(db, newShoppingCart);
                //}
                //while (Console.ReadLine().ToLower() == "y");


            }









            //using (var db = new AdvansedShopDatabaseContext())
            //{
            //    Customer customer = new Customer();

            //    //db.Foods.AddRange(groceries);
            //    //db.SaveChanges();


            //    ShoppingCart newCart = new ShoppingCart();
            //    db.ShoppingCarts.Add(newCart);

            //    do
            //    {
            //        ChooseFood(db, newCart);
            //    }
            //    while (Console.ReadLine().ToLower() == "y");

            //    db.SaveChanges();

            //    var shoppingCarts = db.ShoppingCarts.Include("Items");
            //    foreach (var cart in shoppingCarts)
            //    {
            //        Console.WriteLine(cart.DateCreated);
            //        foreach (var food in cart.Items)
            //        {
            //            Console.WriteLine(food.Name);
            //        }
            //    }
            //}

            Console.ReadLine();




        }



        private static void ChooseFood(ShopDbContext db, ShoppingCart newShoppingCart)
        {
            Console.WriteLine("What do you want to buy? ");
            string foodName = Console.ReadLine().ToLower();
            Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
            newShoppingCart.AddToCard(chosenFood);
            Console.WriteLine("Anything else? Y/N");
        }

        private static string ToFirstUpper(string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
    }
}
