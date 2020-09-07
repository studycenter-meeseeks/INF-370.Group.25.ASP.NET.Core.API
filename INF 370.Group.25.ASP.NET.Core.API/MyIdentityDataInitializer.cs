using System.Linq;
using System.Security.Claims;
using _25.Data.Context;
using _25.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace INF_370.Group._25.ASP.NET.Core.API
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                var role = new IdentityRole { Name = "SuperAdmin" };
                var roleResult = roleManager.CreateAsync(role).Result;

                var dbContext = new ApplicationDbContext();
                var subSystems = dbContext.SubSystems.ToList();
                var operations = dbContext.Operations.ToList();

                var superAdminRole = roleManager.FindByNameAsync(role.Name).Result;

                foreach (var subSystem in subSystems)
                {
                    foreach (var operation in operations)
                    {
                        // Bad memory management, please change when possible
                        var newClaim = new Claim(subSystem.Name, operation.Name + "-" + "True"); 
                        roleManager.AddClaimAsync(superAdminRole, newClaim);
                    }
                }
            }
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("super@calenipractice.co.za").Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "super@calenipractice.co.za",
                    Email = "super@calenipractice.co.za",
                    IsActive = true
                };

                var result = userManager.CreateAsync(user, "Caleni12345!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SuperAdmin").Wait();
                }
            }
        }

        
    }
}