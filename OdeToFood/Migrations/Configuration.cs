using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            for (var i = 0; i < 1000; i++)
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant {Name = i.ToString(), City = "City No. " + i, Country = "Romania"});
        }
    }
}
