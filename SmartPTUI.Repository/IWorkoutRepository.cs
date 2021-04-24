using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public interface IWorkoutRepository
    {
        public Task<int> SaveInitialWorkout(WorkoutPlan workout);
        public Task<WorkoutPlan> GetWorkout(int id);
        public Task<WorkoutWeek> GetWorkoutWeek(int id);

        public Task<WorkoutSession> GetWorkoutSession(int id);

        public Task<ExcersizeMeta> GetExcersizeMeta(int id);

        public Task<int> SaveExcersizeMeta(ExcersizeMeta excersizeMeta);
    }
}
