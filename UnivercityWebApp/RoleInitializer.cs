using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UnivercityWebApp.Models;

namespace UnivercityWebApp
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string password = "Q+azwsxedc123";
            string[] logins = new string[]
            {
                "adminCafedra@gmail.com",
                "adminDecanat@gmail.com",
                "adminRectorat@gmail.com"
            };
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
            if (await userManager.FindByNameAsync(logins[0]) == null)
            {
                var cafedraAdmin = new ApplicationUser 
                {
                    Email = "adminCafedra@gmail.com", 
                    UserName = "adminCafedra@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Patronymic = "Adminovich",
                    EmailConfirmed = true
                };
                var decanatAdmin = new ApplicationUser
                {
                    Email = "adminDecanat@gmail.com",
                    UserName = "adminDecanat@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Patronymic = "Adminovich",
                    EmailConfirmed = true
                };
                var rectoratAdmin = new ApplicationUser
                {
                    Email = "adminRectorat@gmail.com",
                    UserName = "adminRectorat@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Patronymic = "Adminovich",
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(cafedraAdmin, password);
                await userManager.CreateAsync(decanatAdmin, password);
                await userManager.CreateAsync(rectoratAdmin, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(cafedraAdmin, "admin");
                    await userManager.AddToRoleAsync(decanatAdmin, "admin");
                    await userManager.AddToRoleAsync(rectoratAdmin, "admin");
                }
            }
        }
    }
}
