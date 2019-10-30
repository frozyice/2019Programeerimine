using ShopDatabaseAdvanced.models;
using ShopDatabaseAdvanced.ShopDatabaseAdvanced;
using System;
using System.Collections.Generic;
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

            using (var db = new AdvansedShopDatabaseContext())
            {
                //db.Foods.AddRange(groceries);
                //db.SaveChanges();


                ShoppingCart newCart = new ShoppingCart();
                db.ShoppingCarts.Add(newCart);

                do
                {
                    ChooseFood(db, newCart);
                }
                while (Console.ReadLine().ToLower() == "y");

                db.SaveChanges();

                var shoppingCarts = db.ShoppingCarts.Include("Items");
                foreach (var cart in shoppingCarts)
                {
                    Console.WriteLine(cart.DateCreated);
                    foreach(var food in cart.Items)
                    {
                        Console.WriteLine(food.Name);
                    }
                }
            }

            


        }

        private static void ChooseFood(AdvansedShopDatabaseContext db, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy? ");
            string foodName = Console.ReadLine().ToLower();
            Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCard(chosenFood);
            Console.WriteLine("Anything else? Y/N");
        }
    }
}
