using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartPTUI.Business;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewModelRepository _viewModelRepository;

        public HomeController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;

        }

        public async Task<IActionResult> Index()
        {
            //var customers = await _viewModelRepository.GetQuestionnaireViewModel(1);
            return View();
        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
