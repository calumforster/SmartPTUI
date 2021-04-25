using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutSession
    {
        public int WorkoutSessionId { get; set; }
        public IList<ExcersizeMeta> Excersizes { get; set; }
        public WorkoutWeek WorkoutWeek { get; set; }
        public bool isCompletedWorkoutSession { get; set; }
    }
}
