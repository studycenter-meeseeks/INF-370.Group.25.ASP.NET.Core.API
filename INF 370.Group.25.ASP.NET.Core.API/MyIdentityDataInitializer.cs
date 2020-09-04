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

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SuperAdmin").Result)
            {
                var role = new IdentityRole {Name = "SuperAdmin" };
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}