namespace ShopDatabaseAdvanced.Migrations
{
    using ShopDatabaseAdvanced.models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDatabaseAdvanced.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShopDatabaseAdvanced.ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Foods.AddOrUpdate(
                food => food.Name,
                new Food
                {
                    Name = "apple",
                    Price = 1.2
                },
                new Food
                {
                    Name = "bread",
                    Price = 1.2
                },
                new Food
                {
                    Name = "cheese",
                    Price = 2
                },
                new Food
                {
                    Name = "milk",
                    Price = 0.95
                },
                new Food
                {
                    Name = "icecream",
                    Price = 1.3
                },
                new Food
                {
                    Name = "cake",
                    Price = 2
                }
                );
            context.SaveChanges();
        }
    }
}
