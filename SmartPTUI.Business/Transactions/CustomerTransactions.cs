using Microsoft.AspNetCore.Identity;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.ContentRepository;
using SmartPTUI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.Business.Transactions
{
    public class CustomerTransactions : ICustomerTransactions
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerTransactions(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SaveCustomer(Customer customer)
        {

            await _customerRepository.SaveCustomer(customer);
        }


    }
}
