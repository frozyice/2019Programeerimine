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
        public ShopDbContext() : base("AdvancedShopDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Migrations.Configuration>());
        }

        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasMany(c => c.Foods).WithMany(c => c.ShoppingCarts);
            modelBuilder.Entity<Customer>().HasMany(c => c.ShoppingCarts).WithRequired(c => c.Customer).WillCascadeOnDelete();

        }

        //public AdvansedShopDatabaseContext() : base("Advanced Shopping Database")
        //{

        //}

    }
}
