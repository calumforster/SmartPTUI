using Microsoft.EntityFrameworkCore;
using SmartPTUI.Data;
using SmartPTUI.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartPTUI.Business
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SmartPTUIContext _context;
        public CustomerRepository(SmartPTUIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
    }
}
