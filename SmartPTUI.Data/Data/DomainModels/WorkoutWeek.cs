using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutWeek
    {
        public int WorkoutWeekId { get; set; }
        public int StartWeight { get; set; }
        public int EndWeight { get; set; }
        public int CaloriesConsumed { get; set; }
        public IList<WorkoutSession> Workout { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
        public bool isCompletedWorkoutWeek { get; set; }

    }
}
