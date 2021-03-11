
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.Business.ViewModelRepo
{
    public class ViewModelRepository : IViewModelRepository
    {
        private readonly ICustomerRepository _customerRepository;

        public ViewModelRepository(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<QuestionnaireViewModel> GetQuestionnaireViewModel(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return new QuestionnaireViewModel()
            {
                Customer = new CustomerViewModel()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                },
                WorkoutQuestion = new WorkoutQuestion()
            };
        }
    }
}
