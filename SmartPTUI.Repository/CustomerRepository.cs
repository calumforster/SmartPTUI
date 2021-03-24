using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
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

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
  
            return customer;
        }

        public async Task SaveCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

    }
}
