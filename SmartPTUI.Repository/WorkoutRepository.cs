﻿using Microsoft.EntityFrameworkCore;
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
            return await _context.ExcersizeMetas.Include(x => x.ExcersizeType).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveInitialWorkout(WorkoutPlan workout)
        {
            _context.Add(workout);
            await _context.SaveChangesAsync();
            return workout.Id;

        }
    }
}
