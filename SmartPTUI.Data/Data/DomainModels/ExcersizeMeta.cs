using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class ExcersizeMeta
    {
        public int Id { get; set; }
        public int ExcersizeId { get; set; }
        public virtual Excersize ExcersizeType { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
        public WorkoutSession Workout { get; set; }
    }
}
