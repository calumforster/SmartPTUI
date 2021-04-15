using SmartPTUI.Business.ViewModels;
using System.Threading.Tasks;

namespace SmartPTUI.Business.ViewModelRepo
{
    public interface IViewModelRepository
    {
        Task<QuestionnaireViewModel> GetQuestionnaireViewModel(string id);
    }
}