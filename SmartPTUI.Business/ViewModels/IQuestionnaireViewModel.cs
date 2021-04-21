using SmartPTUI.Data.DomainModels;

namespace SmartPTUI.Business.ViewModels
{
    public interface IQuestionnaireViewModel
    {
        CustomerViewModel Customer { get; set; }
        WorkoutQuestion WorkoutQuestion { get; set; }
    }
}