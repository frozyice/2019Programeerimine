using ShopDatabase.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //list kus kõik tooted on
            List<Food> groceries = new List<Food>
            {
                new Food("apple",1.7),
                new Food("bread",1.2),
                new Food("cheese", 2)
            };

            //poekorv
            ShoppingCart newCart = new ShoppingCart();

            //poekorvi newCart lisatakse listist groceries toidud
            foreach (Food food in groceries)
            {
                newCart.Items.Add(food);
            }

            //db loomine
            using (ShopDbContext db = new ShopDbContext())
            {
                //db kõik shopping cartid listakse database
                db.ShoppingCarts.Add(newCart);
                //salvesta muutused
                db.SaveChanges();

                var carts = db.ShoppingCarts;
                foreach (ShoppingCart cart in carts)
                {
                    Console.WriteLine($"Created on {cart.DateCreated}");
                    foreach(Food food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name} Price: {food.Price}");
                    }
                }

                Console.ReadLine();
            }

            
        }
    }
}
