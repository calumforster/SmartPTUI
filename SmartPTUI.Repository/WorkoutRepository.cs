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

        public async Task<WorkoutPlan> GetWorkoutPlan(int id)
        {
           return await _context.WorkoutPlans.AsNoTracking().Include(x => x.Customer).Include(x => x.WorkoutQuestion).Include(x => x.WorkoutWeek).ThenInclude(x => x.Workout).ThenInclude(x => x.Excersizes).ThenInclude(x => x.ExcersizeType).FirstOrDefaultAsync(x => x.WorkoutPlanId == id);
        }

        public async Task<List<WorkoutPlan>> GetWorkoutPlansForCustomer(int customerId)
        {
            return await _context.WorkoutPlans.AsNoTracking().Include(x => x.WorkoutWeek).Include(x => x.WorkoutQuestion).Include(x => x.Customer).Where(x => x.Customer.Id == customerId).ToListAsync();

        }

        public async Task<WorkoutWeek> GetWorkoutWeek(int id)
        {
            return await _context.WorkoutWeeks.AsNoTracking().Include(x => x.WorkoutPlan).Include(x => x.Workout).FirstOrDefaultAsync(x => x.WorkoutWeekId == id);
        }

        public async Task<WorkoutSession> GetWorkoutSession(int id)
        {
           return await _context.WorkoutSessions.AsNoTracking().Include(x => x.WorkoutWeek).Include(x => x.Excersizes).FirstOrDefaultAsync(x => x.WorkoutSessionId == id);
        }

        public async Task<ExcersizeMeta> GetExcersizeMeta(int id)
        {
            return await _context.ExcersizeMetas.AsNoTracking().Include(x => x.Workout).Include(x => x.ExcersizeType).Include(x => x.ExcersizeSet).FirstOrDefaultAsync(x => x.ExcersizeMetaId == id);
        }

        public async Task<int> SaveInitialWorkout(WorkoutPlan workout)
        {

           var customer =  _context.Customers.Where(x => x.Id == workout.Customer.Id).FirstOrDefault();

            workout.Customer = customer;
           
            _context.Add(workout);
            await _context.SaveChangesAsync();
            return workout.WorkoutPlanId;

        }

        public async Task SaveExcersizeMeta(ExcersizeMeta excersizeMeta)
        {
            _context.Entry(excersizeMeta).Property(x => x.ExcersizeFeedbackRating).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.FurtherNotes).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.isCompletedExcersizeMeta).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.RepsGoal).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.SetsGoal).IsModified = true;
            _context.Entry(excersizeMeta).Property(x => x.WeightGoal).IsModified = true;
            await SaveExcersizeSets(excersizeMeta);

            await _context.SaveChangesAsync();

        }


        private async Task SaveExcersizeSets(ExcersizeMeta excersizeMeta)
        {
            foreach (var set in excersizeMeta.ExcersizeSet) 
            {
                _context.Entry(set).Property(x => x.SetName).IsModified = true;
                _context.Entry(set).Property(x => x.RepsAchieved).IsModified = true;
                _context.Entry(set).Property(x => x.RepsInReserve).IsModified = true;
                _context.Entry(set).Property(x => x.WeightAchieved).IsModified = true;
                await _context.SaveChangesAsync();
            }
            
        }


        public async Task SaveExcersizeSetWorkoutCalc(ExcersizeSet excersizeSet, int excersizeMetaId)
        {
           await _context.Database.ExecuteSqlRawAsync("Insert Into ExcersizeSets Values('"+excersizeSet.SetName+"', 0, 0, 0, "+ excersizeMetaId + "); ");
        }



        public async Task SaveWorkoutSession(WorkoutSession workoutSession)
        {
            _context.Entry(workoutSession).Property(x => x.isCompletedWorkoutSession).IsModified = true;
            await _context.SaveChangesAsync();

        }

        public async Task SaveWorkoutWeek(WorkoutWeek workoutWeek)
        {
            _context.Entry(workoutWeek).Property(x => x.isCompletedWorkoutWeek).IsModified = true;
            _context.Entry(workoutWeek).Property(x => x.CaloriesConsumed).IsModified = true;
            await _context.SaveChangesAsync();

        }

        public async Task SaveWorkoutPlan(WorkoutPlan workoutPlan)
        {
            _context.Entry(workoutPlan).Property(x => x.isCompletedWorkoutPlan).IsModified = true;
            await _context.SaveChangesAsync();
        }


    }
}
