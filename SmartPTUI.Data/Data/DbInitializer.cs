using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Data.Data
{
    public class DbInitializer
    {

        public static async Task InitializeAsync(SmartPTUIContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var _context = context;
            var _userManager = userManager;
            var _roleManager = roleManager;
            string[] emails = { "admintest@test.com", "customertest@test.com", "pttest@test.com" };
            List<IdentityRole> roles = new List<IdentityRole>();
            roles.Add(new IdentityRole()
            {
                Name = "SMARTPTUIADMINROLE"
            });

            roles.Add(new IdentityRole()
            {
                Name = "APPUSERROLE"
            });

            roles.Add(new IdentityRole()
            {
                Name = "SMARTPTUIPTROLE"
            });



            Tuple<string, IdentityRole>[] usersWithRoles =
            {
                new Tuple<string, IdentityRole>(emails[0], roles[0]),
                new Tuple<string, IdentityRole>(emails[1], roles[1]),
                new Tuple<string, IdentityRole>(emails[2], roles[2])

            };


            foreach (var userWithRole in usersWithRoles)
            {
                var email = userWithRole.Item1;
                var role = userWithRole.Item2;
                var name = userWithRole.Item1.Split("@")[0];

                var user = new AppUser
                {
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<AppUser>();
                    var hashed = password.HashPassword(user, "Welcome123!");
                    user.PasswordHash = hashed;


                    var result = await _userManager.CreateAsync(user);


                    await _roleManager.CreateAsync(role);
                    await _userManager.AddToRoleAsync(user, role.Name);


                    await context.SaveChangesAsync();



                    if (result.Succeeded)
                    {
                        var customer = new Customer()
                        {
                            FirstName = name,
                            LastName = "Test",
                            Gender = Gender.Male,
                            Height = 170,
                            DOB = DateTime.Now,
                            CurrentHealth = CurrentHealthRating.Fair,
                            UserId = user.Id
                        };
                        context.Add(customer);

                    }

                    await context.SaveChangesAsync();

                }

            }




        }


    }

}

