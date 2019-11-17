using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.models
{
    public class ShoppingCart
    {
        public Guid ShoppingCartId { get; set; } //Primary Key
        public double Sum { get; set; }
        public DateTime DateCreated { get; set; }

        //ONE cart has MANY foods
        public ICollection<Food> Foods { get; set; } 

        //ONE customer has MANY shoppingcars
        public Customer Customer { get; set; } 
        //public Guid CustomerId { get; set; } 

        public ShoppingCart()
        {
            ShoppingCartId = Guid.NewGuid();
            Sum = 0;
            DateCreated = DateTime.Now;

            Foods = new List<Food>();
        }

        internal void AddToCard(Food food)
        {
            Foods.Add(food);
            Sum += food.Price;
        }

        //public void PrintCollection()
        //{

        //}

        //ONE cart has MANY foods
    }
}
