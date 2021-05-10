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
using SmartPTUI.Data.DomainModels;
using SmartPTUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IViewModelRepository _viewModelRepository;
        private readonly IQuestionnaireViewModel _questionnaireViewModel;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DashboardController(ILogger<DashboardController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel, UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction, ICustomerRepository customerRepository, IMapper mapper)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var customer = await _customerRepository.GetCustomerById(user.Id);
            var viewModel = await GetWorkoutPlans(customer.Id);

            return View(viewModel);
        }

        [Authorize(Roles = "SMARTPTUIPTROLE")]
        public async Task<IActionResult> PTndex(int userId)
        {
            var customer = await _customerRepository.GetCustomerByDBId(userId);

            var viewModel = await GetWorkoutPlans(customer.Id);

            return View("Index",viewModel);
        }


        private async Task<DashboardViewModel> GetWorkoutPlans(int customerId)
        {
            var DashboardVm = new DashboardViewModel()
            {
                WorkoutPlans = await _workoutTransaction.GetWorkoutPlansForCustomer(customerId)
            };
            return DashboardVm;
        
        }


    }
}
