using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //ONE Customer has MANY ShoppingCarts
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } 

        public Customer()
            {
            CustomerId = Guid.NewGuid();
            ShoppingCarts = new List<ShoppingCart>();
        }
    }

    
}
