﻿using Microsoft.AspNetCore.Identity;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartPTUI.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
        public DateTime DOB { get; set; }
        public CurrentHealthRating CurrentHealth { get; set; }
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual PersonalTrainer? PersonalTrainer { get; set; }

        public bool isDisabled { get; set; } = false;
    }
}
