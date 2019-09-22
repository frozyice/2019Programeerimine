using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class ShoppingCart
    {

        private List<Food> Items { get; set; }
        private List<int> Amounts { get; set; }
        public double Sum { get; set; }
        
        public ShoppingCart()
        {
            Items = new List<Food>();
            Amounts = new List<int>();
            Sum = 0;
        }

        
        internal void AddToCart(Food chosenFood, int amount)
        {
            Items.Add(chosenFood);
            Amounts.Add(amount);
        }

        internal double CalculateSum()
        {
            for (int i = 0; i < Items.Count(); i++)
            {
                Sum = Sum + Items[i].Price * Amounts[i];
            }

            return Sum;
        }
    }
}