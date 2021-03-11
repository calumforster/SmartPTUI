using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public WorkoutQuestionnaireController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _viewModelRepository.GetQuestionnaireViewModel(1);
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
