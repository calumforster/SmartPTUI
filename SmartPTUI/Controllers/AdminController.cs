using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartPTUI.ContentRepository;
using SmartPTUI.Models;
using System.Threading.Tasks;


namespace SmartPTUI.Controllers
{
    public class AdminController : Controller
    {
        //Injected objects
        private readonly ICustomerRepository _customerRepository;

        public AdminController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Authorize(Roles = "SMARTPTUIADMINROLE")]
        public async Task<IActionResult> Index()
        {
            var customerList = await _customerRepository.GetAllCustomers();

            var viewModel = new AdminViewModel()
            {
                CustomerList = customerList
            };

            return View(viewModel);
        }

        [Authorize(Roles = "SMARTPTUIADMINROLE")]
        public async Task<IActionResult> SubmitCustomerUpdate(AdminViewModel adminViewModel)
        {
            //loops round customers returned from admin, updated database if state change on isDisabled
            for (int i = 0; i < adminViewModel.CustomerList.Count; i++)
            {
                var customer = await _customerRepository.GetCustomerByDBId(adminViewModel.CustomerList[i].Id);
                if (customer.isDisabled != adminViewModel.CustomerList[i].isDisabled)
                {
                    customer.isDisabled = !customer.isDisabled;
                    await _customerRepository.UpdateCustomerAdmin(customer);
                }

            }

            return RedirectToAction("Index", "Admin");
        }

    }
}
