using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Food> groceries = new List<Food>
            {
                new Food("banana", 1.2),
                new Food("apple", 2.3),
                new Food("icecream",2.5)
            };

            Console.WriteLine("Please enter Your firstname: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("Hi, "+firstname+"!");
            Console.ReadLine();

            Console.WriteLine("Please enter Your lastname: ");
            string lastname = Console.ReadLine();

            Person client = new Person(firstname, lastname);

            Console.WriteLine("Welcome to our shop, " + client + "!");

            client.ShoppingCart = new ShoppingCart();
            Console.WriteLine("What do you want to buy?");

            string foodName = Console.ReadLine();

            Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
            if (chosenFood == null)
            {
                Console.WriteLine("we dont have "+foodName);
            }
            else
            {
                Console.WriteLine("How much?");
            }
        }
    }
}
