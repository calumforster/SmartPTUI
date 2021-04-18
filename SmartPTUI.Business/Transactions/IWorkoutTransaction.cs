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
        public Task<WorkoutPlan> GetWorkout(int id);
    }
}
