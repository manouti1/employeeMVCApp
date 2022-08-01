using EmployeeDemoApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDemoApp.Data
{
    public static class DBSeeder
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new Role(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new Role(Enums.Roles.HR.ToString()));
            await roleManager.CreateAsync(new Role(Enums.Roles.Basic.ToString()));
        }

        public static async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

            var adminInfo = config.Get<AdminUserInformation>();

            //Seed Default User
            var defaultUser = new User
            {
                UserName = adminInfo.UserName,
                Email = adminInfo.Email,    
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, adminInfo.Password);
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }
            }
        }

    }
}
