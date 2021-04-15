using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class WorkoutQuestionnaireController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewModelRepository _viewModelRepository;
        private readonly IQuestionnaireViewModel _questionnaireViewModel;
        private readonly UserManager<AppUser> _userManager;
        public WorkoutQuestionnaireController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
            _userManager = userManager;
        }
        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = await _viewModelRepository.GetQuestionnaireViewModel(user.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitForm(QuestionnaireViewModel viewModel)
        {
            if (ModelState.IsValid) 
            {
                var model = viewModel;
            }
            return View();
        }
    }
}
