using ShopDatabaseAdvanced.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced
{
    public class ShopDbContext : DbContext
    {
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasMany(c => c.Foods).WithOptional(c => c.ShoppingCart).WillCascadeOnDelete();
            modelBuilder.Entity<Customer>().HasMany(c => c.ShoppingCarts).WithRequired(c => c.Customer).WillCascadeOnDelete();

        }

    }
}
