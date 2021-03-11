﻿using SmartPTUI.Data.Enums;
using System;

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
    }
}
