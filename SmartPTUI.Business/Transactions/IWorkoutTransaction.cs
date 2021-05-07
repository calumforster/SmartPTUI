using SmartPTUI.Business.ViewModels;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.Business.Transactions
{
    public interface IWorkoutTransaction
    {

        public Task<int> CreateWorkout(QuestionnaireViewModel questionResults);
        public Task<WorkoutPlan> GetWorkoutPlan(int id);

        public Task<WorkoutWeek> GetWorkoutWeek(int id);

        public Task<WorkoutSession> GetWorkoutSession(int id);

        public Task<ExcersizeMeta> GetExcersizeMeta(int id);

        public Task SaveExcersizeMeta(ExcersizeMeta excersizeMeta);

        public Task SaveWorkoutSession(WorkoutSession workoutSession);

        public Task SaveWorkoutWeek(WorkoutWeek workoutWeek);

        public Task SaveWorkoutPlan(WorkoutPlan workoutPlan);

        public Task CalculateNextWorkoutWeek(int workoutPlanId);
    }
}
