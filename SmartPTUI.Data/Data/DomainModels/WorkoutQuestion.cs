using System;
using System.Collections.Generic;
using System.Text;
using SmartPTUI.Data.Enums.WorkoutPlan;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutQuestion
    {
        public int StartWeight { get; set; }
        public int EndWeight { get; set; }
        public Goals Goal { get; set; }
        public int DaysPerWeek { get; set; }
        public int TimePerWorkout { get; set; }
    }
}
