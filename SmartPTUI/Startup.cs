using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Business;
using SmartPTUI.ContentRepository;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;

namespace SmartPTUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartPTUIContext> (options => options.UseSqlServer(Configuration["ConnectionStrings:SmartPTUIContextConnection"]));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IViewModelRepository, ViewModelRepository>();
            services.AddScoped<IQuestionnaireViewModel, QuestionnaireViewModel>();
            services.AddScoped<ICustomerViewModel, CustomerViewModel>();
            services.AddAuthentication();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

    }
}
