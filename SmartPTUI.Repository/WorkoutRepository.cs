using Microsoft.EntityFrameworkCore;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
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
           return await _context.WorkoutPlans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveInitialWorkout(WorkoutPlan workout)
        {
            _context.Add(workout);
            await _context.SaveChangesAsync();
            return workout.Id;

        }
    }
}
