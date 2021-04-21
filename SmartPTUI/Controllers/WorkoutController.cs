using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IWorkoutTransaction _workoutTransaction;
        public WorkoutController(ILogger<WorkoutController> logger, IViewModelRepository viewModelRepository, IWorkoutTransaction workoutTransaction)
        {
            _logger = logger;
            _workoutTransaction = workoutTransaction;
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index(int WorkoutId)
        {
            var workoutPlan = await _workoutTransaction.GetWorkout(WorkoutId);

            return View(workoutPlan);
        }
    }
}
