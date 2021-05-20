using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartPTUI.Data.Enums.WorkoutPlan
{
    public enum Goals
    {
        [Display(Name = "Weight Loss")]
        WeightLoss,
        [Display(Name = "Strength")]
        WeightGain,
        [Display(Name = "Fitness")]
        Fitness
    }
}
