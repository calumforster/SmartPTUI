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

        public async Task<Customer> GetCustomerById(string id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserId.Equals(id));
  
            return customer;
        }

        public async Task<Customer> GetCustomerViaEmail(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.User.Email == email);

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {

            var returnedCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.UserId.Equals(customer.Id));
            returnedCustomer = customer;
            _context.SaveChanges();

            return customer;
        }

        public async Task SaveCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task SavePT(PersonalTrainer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

    }
}
