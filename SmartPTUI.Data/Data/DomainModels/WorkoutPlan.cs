
using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutPlan
    {
        public WorkoutQuestion WorkoutQuestion { get; set; } 
        public IEnumerable<WorkoutWeek> WorkoutWeek { get; set; }
        public Customer Customer { get; set; }



    }
}
