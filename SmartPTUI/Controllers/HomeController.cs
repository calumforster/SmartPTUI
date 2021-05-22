using Microsoft.AspNetCore.Mvc;
using SmartPTUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> FAQ()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
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
