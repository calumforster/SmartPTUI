using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.Transactions;
using SmartPTUI.ContentRepository;
using SmartPTUI.Models;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
            _customerRepository = customerRepository;
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index()
        {
            //gets the list of workout plans assigned to current user
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

            return View("Index", viewModel);
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
