using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Data.DomainModels;
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
        public async Task<IActionResult> Index(int workoutId)
        {
            var workoutPlan = await _workoutTransaction.GetWorkout(workoutId);

            return View(workoutPlan);
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> WorkoutWeek(int id)
        {
            var workoutWeek = await _workoutTransaction.GetWorkoutWeek(id);

            return View(workoutWeek);
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> WorkoutSession(int id)
        {
            var workoutSession = await _workoutTransaction.GetWorkoutSession(id);

            return View(workoutSession);
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> ExcersizeMeta(int id)
        {
            var excersizeMeta = await _workoutTransaction.GetExcersizeMeta(id);

            return View(excersizeMeta);
        }

        [Authorize(Roles = "APPUSERROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitExcersizeMeta(ExcersizeMeta excersizeMeta)
        {

            if (!ModelState.IsValid)
            {
                return View("ExcersizeMeta", excersizeMeta);
            }

            var workoutSessionId = await _workoutTransaction.SaveExcersizeMeta(excersizeMeta);

            return RedirectToAction("WorkoutSession", "Workout", new {id = workoutSessionId });
        }
    }
}
