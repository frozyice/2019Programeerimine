using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ShopMVC.DatabaseContext
{
    public class ShopDbinitializer : DropCreateDatabaseIfModelChanges<ShopDbContext>
    {
        protected override void Seed(ShopDbContext context)
        {
            context.Foods.AddOrUpdate(x => x.Name,
            new Food
            {
                Name = "apple",
                Price = 1
            },

            new Food

            {
                Name = "banana",
                Price = 3
            }
                );
        }
    }
}