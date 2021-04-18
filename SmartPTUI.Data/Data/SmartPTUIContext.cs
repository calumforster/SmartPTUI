using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using SmartPTUI.Data.Data.DomainModels;
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
        public DbSet<ExcersizeMeta> ExcersizeMetas { get; set; }
        public DbSet<WorkoutFeedback> WorkoutFeedbacks { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutWeek> WorkoutWeeks { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutQuestion> WorkoutQuestions { get; set; }
    }
}
