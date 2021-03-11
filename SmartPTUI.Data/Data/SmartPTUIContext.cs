using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;

namespace SmartPTUI.Data
{
    public class SmartPTUIContext : IdentityDbContext<SmartPTUICustomer, IdentityRole, string>
    {
        public SmartPTUIContext(DbContextOptions<SmartPTUIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
