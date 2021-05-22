using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Business.ViewModels;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using SmartPTUI.Models;
using System;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class PTController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewModelRepository _viewModelRepository;
        private readonly IQuestionnaireViewModel _questionnaireViewModel;
        private readonly ICustomerRepository _customerRepository;
        private readonly IWorkoutTransaction _workoutTransaction;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public PTController(ILogger<HomeController> logger, IViewModelRepository viewModelRepository, IQuestionnaireViewModel questionnaireViewModel, UserManager<AppUser> userManager, IWorkoutTransaction workoutTransaction, ICustomerRepository customerRepository, IMapper mapper)
        {
            _logger = logger;
            _viewModelRepository = viewModelRepository;
            _questionnaireViewModel = questionnaireViewModel;
            _userManager = userManager;
            _workoutTransaction = workoutTransaction;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }


        [Authorize(Roles = "SMARTPTUIPTROLE")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var pt = await _customerRepository.GetPTByUserId(user.Id);
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
            try
            {
                pt.Customers.Add(await _customerRepository.GetCustomerViaEmail(customerEmail));
                await _customerRepository.UpdatePT(pt);
            }
            catch (Exception e)
            {


            }


            return RedirectToAction("Index", "PT");
        }
    }
}
