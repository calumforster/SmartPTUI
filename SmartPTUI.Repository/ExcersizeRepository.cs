using Microsoft.EntityFrameworkCore;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public class ExcersizeRepository : IExcersizeRepository
    {
        private readonly SmartPTUIContext _context;
        public ExcersizeRepository(SmartPTUIContext context)
        {
            _context = context;
        }

        public async Task<Excersize> GetChestExcersize()
        {
            return await _context.ExcersizeStore.FirstOrDefaultAsync(x => x.CoreArea.Equals(WorkoutArea.Chest));

        }

        public async Task<Excersize> GetBackExcersize()
        {
            return await _context.ExcersizeStore.FirstOrDefaultAsync(x => x.CoreArea.Equals(WorkoutArea.Back));
        }

        public async Task<Excersize> GetShouldersExcersize()
        {
            return await _context.ExcersizeStore.FirstOrDefaultAsync(x => x.CoreArea.Equals(WorkoutArea.Shoulders));
        }

        public async Task<Excersize> GetLegsExcersize()
        {
            return await _context.ExcersizeStore.FirstOrDefaultAsync(x => x.CoreArea.Equals(WorkoutArea.Legs));
        }

        public async Task<Excersize> GetExcersizeWithWorkoutArea(int workoutAreaId)
        {

            WorkoutArea workoutEnum = (WorkoutArea)workoutAreaId;
            return await _context.ExcersizeStore.FirstOrDefaultAsync(x => x.CoreArea == workoutEnum);
        }


    }
}
