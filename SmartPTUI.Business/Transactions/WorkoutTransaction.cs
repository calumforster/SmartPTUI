using SmartPTUI.ContentRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Business.Transactions
{
    public class WorkoutTransaction : IWorkoutTransaction
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutTransaction(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
    }
}
