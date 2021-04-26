using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SmartPTUI.Data.Enums.WorkoutPlan;

namespace SmartPTUI.Data.DomainModels
{
    public class WorkoutQuestion
    {
        public int Id { get; set; }
        [Display(Name = "Starting Weight (Kg's)", Prompt = "e.g 100")]
        [Range(40, 200)]
        [Required]
        public int? StartWeight { get; set; }

        [Display(Name = "Target Weight (Kg's)", Prompt = "e.g 90")]
        [Range(40, 200)]
        [Required]
        public int? EndWeight { get; set; }

        [Display(Name = "Goal", Prompt = "Select From Dropdown")]
        [Required]
        public Goals Goal { get; set; }

        [Display(Name = "Days a week for Workout", Prompt = "How many Days you have for a workout")]
        [Range(1, 7)]
        [Required]
        public int? DaysPerWeek { get; set; }

        [Display(Name = "Time Per workout", Prompt = "How much time per workout")]
        [Range(10, 200)]
        [Required]
        public int? TimePerWorkout { get; set; }

        [Display(Name = "Workout Name", Prompt = "e.g My First Workout")]
        [Required]
        public string WorkoutName { get; set; }
    }
}
