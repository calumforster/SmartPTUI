using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        public IList<ExcersizeMeta> Excersizes { get; set; }
        public WorkoutFeedback Feedback { get; set; }
        public WorkoutWeek WorkoutWeek { get; set; }
    }
}
