using SmartPTUI.Data.Data.Enums.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartPTUI.Data.DomainModels
{
    public class ExcersizeMeta
    {
        public int ExcersizeMetaId { get; set; }
        public int ExcersizeId { get; set; }
        public List<ExcersizeSet> ExcersizeSet { get; set; }
        #nullable enable
        public virtual Excersize? ExcersizeType { get; set; }
        public int SetsGoal { get; set; }
        public int RepsGoal { get; set; }        
        public int WeightGoal { get; set; }
   
        #nullable enable
        public virtual WorkoutSession? Workout { get; set; }
        [Display(Name = "How do you feel after the excersize?")]
        [Required]
        public ExcersizeFeedbackRating? ExcersizeFeedbackRating { get; set; }
        [Display(Name = "Additional Notes")]
        public string? FurtherNotes { get; set; }
        public bool isCompletedExcersizeMeta { get; set; }
    }
}
