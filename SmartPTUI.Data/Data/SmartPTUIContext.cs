using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using SmartPTUI.Data.Enums;
using System;

namespace SmartPTUI.Data
{
    public class SmartPTUIContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
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
                Id = 999999,
                FirstName = "John",
                LastName = "Smith",
                Gender = Gender.Male,
                Height = 170,
                DOB = DateTime.Now,
                CurrentHealth = CurrentHealthRating.Fair
                //User = new AppUser()
            });
        }


        public DbSet<Customer> Customers { get; set; }
    }
}
