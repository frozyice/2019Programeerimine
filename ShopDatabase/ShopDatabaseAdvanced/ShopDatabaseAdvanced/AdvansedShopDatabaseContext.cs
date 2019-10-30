using ShopDatabaseAdvanced.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.ShopDatabaseAdvanced
{
    class AdvansedShopDatabaseContext : DbContext
    {

        public AdvansedShopDatabaseContext () : base("Advanced Shopping Database")
        {

        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Food> Foods { get; set; }
    }
}
