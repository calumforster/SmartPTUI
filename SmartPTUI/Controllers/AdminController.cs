using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Models;
using System;
using System.Threading.Tasks;


namespace SmartPTUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewModelRepository _viewModelRepository;
        private readonly IQuestionnaireViewModel _questionnaireViewModel;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel, UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction, ICustomerRepository customerRepository, IMapper mapper)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "SMARTPTUIADMINROLE")]
        public async Task<IActionResult> Index()
        {
           var customerList =  await _customerRepository.GetAllCustomers();

            var viewModel = new AdminViewModel()
            {
                CustomerList = customerList
            };

            return View(viewModel);
        }

        [Authorize(Roles = "SMARTPTUIADMINROLE")]
        public async Task<IActionResult> SubmitCustomerUpdate(AdminViewModel adminViewModel)
        {

            for (int i = 0; i < adminViewModel.CustomerList.Count; i++)
            {
               var customer =  await _customerRepository.GetCustomerByDBId(adminViewModel.CustomerList[i].Id);
                if (customer.isDisabled != adminViewModel.CustomerList[i].isDisabled)
                {
                    customer.isDisabled = !customer.isDisabled;
                    await _customerRepository.UpdateCustomerAdmin(customer);
                }

            }

            return RedirectToAction("Index", "Admin");
        }

    }
}
