using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.ContentRepository;
using SmartPTUI.Models;
using System;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class PTController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<AppUser> _userManager;

        public PTController(UserManager<AppUser> userManager, ICustomerRepository customerRepository)
        {
            _userManager = userManager;
            _customerRepository = customerRepository;
        }


        [Authorize(Roles = "SMARTPTUIPTROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pt = await _customerRepository.GetPTByUserId(user.Id);

            //sets the viewModel state
            var ptViewModel = new PTPageViewModel()
            {
                PersonalTrainer = pt,
                CustomerEmail = ""
            };


            return View(ptViewModel);
        }


        [Authorize(Roles = "SMARTPTUIPTROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitCustomerAddition(PTPageViewModel ptPageModel)
        {

            var customerEmail = ptPageModel.CustomerEmail;

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pt = await _customerRepository.GetPTByUserId(user.Id);

            //attempts to find the customer entered via db call
            try
            {
                pt.Customers.Add(await _customerRepository.GetCustomerViaEmail(customerEmail));
                await _customerRepository.UpdatePT(pt);
            }
            catch (Exception e)
            {
                //if logging is implemented for a non found users

            }


            return RedirectToAction("Index", "PT");
        }
    }
}
