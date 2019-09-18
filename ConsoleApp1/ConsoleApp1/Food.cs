using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Food
    {
        public String Name { get; set; }

        public double Price { get; set; }

        public Food (string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
