using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartPTUI.Data.DomainModels
{
    public class ExcersizeSet
    {
        public int ExcersizeSetId { get; set; }
        public string SetName { get; set; }
        [Display(Name = "Reps Achieved")]
        [Range(1, 100)]
        [Required]
        public int RepsAchieved { get; set; }
        [Display(Name = "Weight Achieved KG's")]
        [Range(1, 400)]
        [Required]
        public int WeightAchieved { get; set; }
        [Display(Name = "Reps In Reserve")]
        [Range(1, 20)]
        [Required]
        public int RepsInReserve { get; set; }
    }
}
