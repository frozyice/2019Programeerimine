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
            new Food("apple", 1.7),
            new Food("bread", 1.2),
            new Food("cheese", 2)
            };

            //Food apple = new Food("apple", 1.7);


            //poekorv
            ShoppingCart newCart = new ShoppingCart();

            //do
            //{
            //    chooseFood(groceries, newCart);
            //}
            //while (Console.ReadLine().ToLower() == "y");



            //poekorvi newCart lisatakse listist groceries toidud
            //foreach (Food food in groceries)
            //{
            //    newCart.Items.Add(food);
            //}


            //db loomine
            using (ShopDbContext db = new ShopDbContext())
            {
                IQueryable<ShoppingCart> cartWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
                foreach(ShoppingCart cart in cartWithZeroSum)
                {
                    db.ShoppingCarts.Remove(cart);
                }
                
                //db kõik shopping cartid listakse database
                db.ShoppingCarts.Add(newCart);
                //salvesta muutused
                db.SaveChanges();

                List<ShoppingCart> carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
                foreach (ShoppingCart cart in carts)
                {
                    Console.WriteLine($"Created on {cart.DateCreated}");
                    foreach (Food food in cart.Items)
                    {
                        Console.WriteLine($"Name: {food.Name} Price: {food.Price}");
                    }
                }









                //    Console.WriteLine("-----------------------------------");
                //carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
                //Console.WriteLine($"Created on {carts[0].DateCreated}");
                //Console.WriteLine(carts[0].Items);

                //foreach (Food food in carts[0].Items)
                //{
                //    Console.WriteLine("test");
                //    Console.WriteLine($"Name: {food.Name} Price: {food.Price}");
                //}

                System.Data.Entity.Infrastructure.DbQuery<ShoppingCart> shcarts = db.ShoppingCarts;
                System.Data.Entity.Infrastructure.DbQuery<ShoppingCart> cartsWithItems = db.ShoppingCarts.Include("Items");
                System.Data.Entity.Infrastructure.DbQuery<Food> foods = db.Foods;

                //1.show only the last(latest created) shopping cart with all its items
                ShoppingCart latest = cartsWithItems.OrderBy(cart => cart.DateCreated).ToList().First(); //lamda expression
                //or
                ShoppingCart latest2 = cartsWithItems.OrderBy(cart => cart.DateCreated).ToList().Last();

                //2.show only the carts with sum > 5
                List<ShoppingCart> largerThanFive = shcarts.Where(cart => cart.Sum > 5).ToList();
                foreach (var cart in largerThanFive)
                {
                    Console.WriteLine($"ShoppingCart {cart.DateCreated} {cart.Sum}");
                }

                //3.show only the carts with more than one item in it(and how many items is in cart)
                IQueryable<ShoppingCart> cartsMoreThanOne = cartsWithItems.Where(cart => cart.Items.Count() > 1);
                foreach (var cart in cartsMoreThanOne)
                {
                    Console.WriteLine(cart.DateCreated);
                }

                // LINQ
                cartsMoreThanOne = from cart in cartsWithItems where cart.Items.Count() > 1 select cart;

                //4.show only the carts that contain apples
                IQueryable<ShoppingCart> cartsWithApples = cartsWithItems.Where(cart => cart.Items.Any(y => y.Name == "apple"));

                //5.show the total number of shopping carts
                int totalShCatrs = shcarts.Count();

                //6.show the cart with maximum sum
                ShoppingCart maxSumShoppingcart = shcarts.OrderByDescending(cart => cart.Sum).FirstOrDefault();

                //7.show the cheapest food
                Food cheapestFood = foods.OrderBy(food => food.Price).FirstOrDefault();

                Console.ReadLine();
            }


        }

        private static void chooseFood(List<Food> groceries, ShoppingCart newCart)
        {
            Console.WriteLine("What do you want to buy? ");
            string foodName = Console.ReadLine().ToLower();
            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
            newCart.AddToCard(chosenFood);
            Console.WriteLine("Anything else? Y/N");
        }
    }
}
