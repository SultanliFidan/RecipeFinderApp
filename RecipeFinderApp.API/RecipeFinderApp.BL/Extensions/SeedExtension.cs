using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Extensions
{
    public static class SeedExtension
    {
        public static void UseUserSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                CreateRoles(roleManager).Wait();
                CreateUsers(userManager).Wait();
            }
        }

        public static async Task CreateRoles(RoleManager<IdentityRole> _roleManager)
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                foreach (Roles role in Enum.GetValues(typeof(Roles)))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.GetRole()));
                }
            }
        }

        public static async Task CreateUsers(UserManager<User> _userManager)
        {
            if (!await _userManager.Users.AnyAsync(u => u.NormalizedUserName == "ADMIN"))
            {
                User user = new User();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                user.Fullname = "admin";
               
                string role = nameof(Roles.Admin);
                await _userManager.CreateAsync(user, "123");
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
