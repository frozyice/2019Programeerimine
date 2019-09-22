using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Food
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Food(string name, double price)
        {
           Name = name;
           Price = price;
        }
    }
}
