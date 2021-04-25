
using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public WorkoutQuestion WorkoutQuestion { get; set; } 
        public IList<WorkoutWeek> WorkoutWeek { get; set; }
        public virtual Customer Customer { get; set; }



    }
}
