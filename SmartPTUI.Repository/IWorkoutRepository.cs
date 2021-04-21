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
    }
}
