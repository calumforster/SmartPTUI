using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class PTController : Controller
    {
        [Authorize(Roles = "SMARTPTUIPTROLE")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
