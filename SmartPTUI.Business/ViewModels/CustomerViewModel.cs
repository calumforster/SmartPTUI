using SmartPTUI.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartPTUI.Business.ViewModels
{
    public class CustomerViewModel : ICustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
        public DateTime DOB { get; set; }
        [Display(Name = "Your Current Health Rating")]
        [Required]
        public CurrentHealthRating CurrentHealth { get; set; }
    }
}
