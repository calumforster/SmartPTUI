﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutWeek
    {
        public int Id { get; set; }
        public int StartWeight { get; set; }
        public int EndWeight { get; set; }
        public int CaloriesConsumed { get; set; }
        public IList<WorkoutSession> Workout { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
 
    }
}
