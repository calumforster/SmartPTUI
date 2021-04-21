using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.ContentRepository;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Data.Data;
using AutoMapper;
using SmartPTUI.Business;

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

            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<SmartPTUIContext>();
            builder.AddRoleValidator<RoleValidator<IdentityRole>>();
            builder.AddRoleManager<RoleManager<IdentityRole>>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddTransient<UserManager<AppUser>>();
            services.AddDbContext<SmartPTUIContext> (options => options.UseSqlServer(Configuration["ConnectionStrings:SmartPTUIContextConnection"]), ServiceLifetime.Transient);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IViewModelRepository, ViewModelRepository>();
            services.AddScoped<IQuestionnaireViewModel, QuestionnaireViewModel>();
            services.AddScoped<ICustomerViewModel, CustomerViewModel>();
            services.AddScoped<ICustomerTransactions, CustomerTransactions>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IWorkoutTransaction, WorkoutTransaction>();
            services.AddScoped<IExcersizeRepository, ExcersizeRepository>();
            services.AddTransient<SmartPTUIContext>();
            services.AddAuthentication();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, SmartPTUIContext dbContext ,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
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

            DbInitializer.InitializeAsync(dbContext, userManager, roleManager).Wait();
        }

    }
}
