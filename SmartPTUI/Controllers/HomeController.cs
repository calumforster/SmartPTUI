using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartPTUI.Business;
using SmartPTUI.Data;
using SmartPTUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;

        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetCustomersAsync();
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
