using SmartPTUI.Business.ViewModels;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Business.ViewModels
{
    public class QuestionnaireViewModel : IQuestionnaireViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public WorkoutQuestion WorkoutQuestion { get; set; }
    }
}
