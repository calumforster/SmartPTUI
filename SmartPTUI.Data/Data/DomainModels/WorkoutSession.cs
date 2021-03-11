using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutSession
    {
        public IEnumerable<Excersize> Excersizes { get; set; }
        public WorkoutFeedback Feedback { get; set; }
    }
}
