using Microsoft.EntityFrameworkCore;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly SmartPTUIContext _context;
        public WorkoutRepository(SmartPTUIContext context)
        {
            _context = context;
        }

        public async Task<WorkoutPlan> GetWorkout(int id)
        {
           return await _context.WorkoutPlans.Include(x => x.WorkoutWeek).ThenInclude(x => x.Workout).ThenInclude(x => x.Excersizes).ThenInclude(x => x.ExcersizeType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkoutWeek> GetWorkoutWeek(int id)
        {
            return await _context.WorkoutWeeks.Include(x => x.Workout).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkoutSession> GetWorkoutSession(int id)
        {
            return await _context.WorkoutSessions.Include(x => x.Excersizes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExcersizeMeta> GetExcersizeMeta(int id)
        {
            return await _context.ExcersizeMetas.Include(x => x.ExcersizeType).FirstOrDefaultAsync(x => x.ExcersizeMetaId == id);
        }

        public async Task<int> SaveInitialWorkout(WorkoutPlan workout)
        {

           var customer =  _context.Customers.Where(x => x.Id == workout.Customer.Id).FirstOrDefault();

            workout.Customer = customer;
           
            _context.Add(workout);
            await _context.SaveChangesAsync();
            return workout.Id;

        }

        public async Task<int> SaveExcersizeMeta(ExcersizeMeta excersizeMeta)
        {
            _context.Entry(excersizeMeta).Property(x => x.RepsAchieved).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.SetsAchieved).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.WeightAchieved).IsModified = true;

            await _context.SaveChangesAsync();

            //TODO Make stored PROC
           var workoutSession = await _context.WorkoutSessions.FromSqlRaw("SELECT * FROM WorkoutSessions Inner JOIN ExcersizeMetas ON WorkoutSessions.Id = ExcersizeMetas.WorkoutId WHERE ExcersizeMetas.ExcersizeMetaId = {0}", excersizeMeta.ExcersizeMetaId).FirstOrDefaultAsync();

            return workoutSession.Id;
        }
    }
}
