using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class AdminPage : Controller
    {
        [Authorize(Roles = "SMARTPTUIADMINROLE")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
