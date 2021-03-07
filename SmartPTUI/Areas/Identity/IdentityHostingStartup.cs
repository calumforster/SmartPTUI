using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;

[assembly: HostingStartup(typeof(SmartPTUI.Areas.Identity.IdentityHostingStartup))]
namespace SmartPTUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SmartPTUIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SmartPTUIContextConnection")));
                services.AddDefaultIdentity<SmartPTUICustomer>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<SmartPTUIContext>();

            });
        }


    }
}