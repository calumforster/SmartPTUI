using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using SmartPTUI.Data.Enums;
using System;
using System.Collections.Generic;

namespace SmartPTUI.Data
{
    public class SmartPTUIContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        private readonly UserManager<AppUser> _userManager;
        public SmartPTUIContext(DbContextOptions<SmartPTUIContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<AppUser>().HasData(new AppUser() { 
            
            });
            builder.Entity<Customer>().HasData(new Customer()
            {
                Id = 20000,
                FirstName = "Admin",
                LastName = "Test",
                Gender = Gender.Male,
                Height = 170,
                DOB = DateTime.Now,
                CurrentHealth = CurrentHealthRating.Fair,
                //User = SeedUsers("admin@test.com","SMARTPTUIADMINROLE")
            });
        }

        public AppUser SeedUsers(string email, string role) 
        {
            
            if (_userManager.FindByEmailAsync(email).Result == null)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = email,
                    Email = email
                };

                IdentityResult result = _userManager.CreateAsync(appUser, "Welcome123!").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(appUser, role);
                }

                return appUser;
            }
            else 
            {
                return null;
            }
        }


        public DbSet<Customer> Customers { get; set; }
    }
}
