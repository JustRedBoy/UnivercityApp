using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UnivercityWebApp.Models;

namespace UnivercityWebApp
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Q+azwsxedc123";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("student") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("student"));
            }
            if (await roleManager.FindByNameAsync("teacher") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("teacher"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser 
                {
                    Email = adminEmail, 
                    UserName = adminEmail,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Patronymic = "Adminovich",
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
