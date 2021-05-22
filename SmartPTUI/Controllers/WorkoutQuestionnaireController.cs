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
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class WorkoutQuestionnaireController : Controller
    {
        private readonly IViewModelRepository _viewModelRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public WorkoutQuestionnaireController(IViewModelRepository viewModelRepository, UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction, ICustomerRepository customerRepository, IMapper mapper)
        {
            _viewModelRepository = viewModelRepository;
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            //Initiates the ViewModel
            var model = await _viewModelRepository.GetQuestionnaireViewModel(user.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm(QuestionnaireViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            //Maps any updated customer information
            var updatedCustomer = await _customerRepository.UpdateCustomer(_mapper.Map<CustomerViewModel, Customer>(viewModel.Customer));

            viewModel.Customer = _mapper.Map<Customer, CustomerViewModel>(updatedCustomer);

            var workoutId = await _workoutTransaction.CreateWorkout(viewModel);

            return RedirectToAction("Index", "Workout", new { WorkoutId = workoutId });
        }
    }
}
