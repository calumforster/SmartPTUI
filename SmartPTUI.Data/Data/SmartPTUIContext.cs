using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Excersize> ExcersizeStore { get; set; }
    }
}
