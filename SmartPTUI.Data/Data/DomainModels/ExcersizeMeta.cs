using SmartPTUI.Data.Data.Enums.Feedback;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class ExcersizeMeta
    {
        public int ExcersizeMetaId { get; set; }
        public int ExcersizeId { get; set; }
        #nullable enable
        public virtual Excersize? ExcersizeType { get; set; }
        public int SetsGoal { get; set; }
        public int RepsGoal { get; set; }
        public int WeightGoal { get; set; }
        [Display(Name = "Weight Used (KG's)", Prompt = "e.g 50")]
        [Range(0, 50, ErrorMessage = "Sets must be between 0 and 50")]
        [Required]
        public int SetsAchieved { get; set; }
        [Display(Name = "Sets Completed", Prompt = "e.g 10")]
        [Range(0, 50, ErrorMessage = "Reps must be between 0 and 50")]
        [Required]
        public int RepsAchieved { get; set; }
        [Display(Name = "Reps Completed", Prompt = "e.g 15")]
        [Range(0, 400, ErrorMessage = "Weight must be between 0 and 400")]
        [Required]
        public int WeightAchieved { get; set; }
        #nullable enable
        public virtual WorkoutSession? Workout { get; set; }
        [Display(Name = "How do you feel after the excersize?")]
        [Required]
        public ExcersizeFeedbackRating? ExcersizeFeedbackRating { get; set; }
        [Display(Name = "AdditionalNotes")]
        public string? FurtherNotes { get; set; }
        public bool isCompletedExcersizeMeta { get; set; }
    }
}
