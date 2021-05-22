using AutoMapper;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Data.DomainModels;
using System.Threading.Tasks;

namespace SmartPTUI.Business.ViewModelRepo
{
    public class ViewModelRepository : IViewModelRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ViewModelRepository(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        //Builds view model containing customer and empty workout question model
        public async Task<QuestionnaireViewModel> GetQuestionnaireViewModel(string id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            return new QuestionnaireViewModel()
            {
                Customer = _mapper.Map<Customer, CustomerViewModel>(customer),
                WorkoutQuestion = new WorkoutQuestion()
            };
        }
    }
}
