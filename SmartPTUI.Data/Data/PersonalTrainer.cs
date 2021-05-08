using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPTUI.Data
{
    public class PersonalTrainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string UserId { get; set; }

        public virtual AppUser User { get; set; }

        public List<Customer> Customers { get; set; }

        public string TitleColour { get; set; }

        public string TextColour { get; set; }

        public string BackgorundColour { get; set; }

        public string TopBarColour { get; set; }

        public string SiteName { get; set; }

        public string WelcomeMessage { get; set; }

    }

    }