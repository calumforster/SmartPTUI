using SmartPTUI.Data.Enums.WorkoutPlan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class Excersize
    {
        public int Id { get; set; }
        public int TimePerRep { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutDescription { get; set; }
        public WorkoutArea CoreArea { get; set; }

    }
}
