
using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public WorkoutQuestion WorkoutQuestion { get; set; } 
        public IList<WorkoutWeek> WorkoutWeek { get; set; }
        public Customer Customer { get; set; }



    }
}
