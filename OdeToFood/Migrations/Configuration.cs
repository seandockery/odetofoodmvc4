using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace OdeToFood.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                new Restaurant { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews =
                        new List<RestaurantReview> {
                            new RestaurantReview { Rating = 9, Body = "Great food!", ReviewerName = "Sean" }
                        }
                });

            SeedMembership(context);
        }

        private void SeedMembership(DbContext context)
        {
            if (!WebSecurity.Initialized)
            {
                // Connection name should match connection name used in OdeToFoodDb constructor.
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }
            if (membership.GetUser("sallen", false) == null)
            {
                membership.CreateUserAndAccount("sallen", "imalittleteapot");
            }
            if (!roles.GetRolesForUser("sallen").Contains("admin"))
            {
                roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
            }
        }
    }
}
