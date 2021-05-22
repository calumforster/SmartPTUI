using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data.DomainModels;

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
        public DbSet<ExcersizeMeta> ExcersizeMetas { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutWeek> WorkoutWeeks { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutQuestion> WorkoutQuestions { get; set; }
        public DbSet<ExcersizeSet> ExcersizeSets { get; set; }
        public DbSet<PersonalTrainer> PersonalTrainer { get; set; }
    }
}
