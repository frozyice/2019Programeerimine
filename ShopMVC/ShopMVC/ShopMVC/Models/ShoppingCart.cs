using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public double Sum { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        public ShoppingCart()
        {
            Id = Guid.NewGuid();
            Sum = 0;
            DateCreated = DateTime.Now;
            Foods = new List<Food>();
        }

        public void AddToCart(Food food)
        {
            Foods.Add(food);
            Sum += food.Price;
        }
    }
}