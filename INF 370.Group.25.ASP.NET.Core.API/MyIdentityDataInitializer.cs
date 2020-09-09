using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            SeedRoles(roleManager).Wait();
            SeedUsers(userManager).Wait();
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            var roleExist = await roleManager.RoleExistsAsync("SuperAdmin".ToLower());
            if (!roleExist)
            {
                var role = new IdentityRole { Name = "SuperAdmin".ToLower() };
                var roleResult = await roleManager.CreateAsync(role);

                var dbContext = new ApplicationDbContext();
                var subSystems = dbContext.SubSystems.ToList();
                var operations = dbContext.Operations.ToList();

                var superAdminRole = await roleManager.FindByNameAsync(role.Name);

                foreach (var subSystem in subSystems)
                {
                    foreach (var operation in operations)
                    {
                        // Bad memory management, please change when possible
                        var newClaim = new Claim(subSystem.Name.ToLower(), operation.Name.ToLower() + "-" + "True".ToLower());
                        await roleManager.AddClaimAsync(superAdminRole, newClaim);
                    }
                }
            }
        }

        public static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var userExists = await userManager.FindByEmailAsync("super@calenipractice.co.za");
            if (userExists == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "super@calenipractice.co.za",
                    Email = "super@calenipractice.co.za",
                    IsActive = true
                };

                var result = await userManager.CreateAsync(user, "Caleni12345!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }


    }
}