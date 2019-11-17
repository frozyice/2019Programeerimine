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
                
                

               


                //Determine if this client exists in the database
                Customer currentCustomer;
                Customer customerInDatabase = (customersFromDb.FirstOrDefault(customer => customer.FirstName == firstName && customer.LastName == lastName));
                bool isNewCustomer;

                if (customerInDatabase==null)
                {
                    //If client doesn't exist, add him or her to the database
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

                //Create a new Shopping Cart and let your client do the shopping.
                ShoppingCart newShoppingCart = new ShoppingCart();
                currentCustomer.ShoppingCarts.Add(newShoppingCart);
                if (isNewCustomer)
                    db.Customers.Add(currentCustomer);
                db.SaveChanges();

                DbQuery<Food> FoodsFromDb = db.Foods;
                Food foodInDatabase = (FoodsFromDb.FirstOrDefault(food => food.Name == "apple"));
                newShoppingCart.Foods.Add(foodInDatabase);
                db.SaveChanges();

                //Show the contents of the current shopping cart together with the its total price.
                DbQuery<ShoppingCart> ShopingCartsWithFoodFromDb = db.ShoppingCarts.Include("Foods");

                Console.WriteLine("All carts-----------------");
                foreach (ShoppingCart cart in ShopingCartsWithFoodFromDb)
                {
                    Console.WriteLine(cart.DateCreated);
                    foreach (Food food in cart.Foods)
                    {
                        if (food!=null) Console.WriteLine(food.Name);
                    }
                   
                }

                


            }


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
