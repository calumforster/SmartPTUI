using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class WorkoutQuestionnaireController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewModelRepository _viewModelRepository;
        private readonly IQuestionnaireViewModel _questionnaireViewModel;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;
        public WorkoutQuestionnaireController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel, UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
        }
        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
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
            var workoutId = await _workoutTransaction.CreateWorkout(viewModel);
            return RedirectToAction("Index", "Workout", new { WorkoutId = workoutId });
        }
    }
}
