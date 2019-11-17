using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.models
{
    public class Food
    {
        public Guid FoodId { get; set; } //Primary Key
        public string Name { get; set; }
        public double Price { get; set; }

        //MANY carts has MANY foods
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        //public Guid ShoppingCartId { get; set; } //Foreign Key 



        //public Food() { }
        public Food(string name, double price)
        {
            FoodId = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Food()
        {
            FoodId = Guid.NewGuid();
        }
    }
}
