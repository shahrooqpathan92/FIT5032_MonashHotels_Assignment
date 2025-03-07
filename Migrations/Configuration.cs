namespace FIT5032_MonashHotels_Assignment.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FIT5032_MonashHotels_Assignment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FIT5032_MonashHotels_Assignment.Models.ApplicationDbContext";
        }

        protected override void Seed(FIT5032_MonashHotels_Assignment.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(new IdentityRole("Admin"));
            context.Roles.AddOrUpdate(new IdentityRole("Owner"));
            context.Roles.AddOrUpdate(new IdentityRole("Customer"));
        }
    }
}
