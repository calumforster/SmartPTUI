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
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            var customer = await _context.Customers.AsNoTracking().Include(x=> x.PersonalTrainer).FirstOrDefaultAsync(x => x.UserId.Equals(id));
  
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customerList = await _context.Customers.AsNoTracking().Include(x => x.User).ToListAsync();

            return customerList;
        }

        public async Task<PersonalTrainer> GetPTById(int id)
        {
            var pt = await _context.PersonalTrainer.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return pt;
        }

        public async Task<Customer> GetCustomerByDBId(int id)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return customer;
        }

        public async Task<PersonalTrainer> GetPTByUserId(string id)
        {
            var pt = await _context.PersonalTrainer.AsNoTracking().Include(x => x.Customers).FirstOrDefaultAsync(x => x.UserId.Equals(id));

            return pt;
        }

        public async Task<Customer> GetCustomerViaEmail(string email)
        {
            var customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.User.Email == email);

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {

            var returnedCustomer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.UserId.Equals(customer.Id));
            returnedCustomer = customer;
            _context.SaveChanges();

            return customer;
        }

        public async Task UpdateCustomerAdmin(Customer customer)
        {
                _context.Entry(customer).Property(x => x.isDisabled).IsModified = true;
                await _context.SaveChangesAsync();
           
        }

        public async Task SaveCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task SavePT(PersonalTrainer pt)
        {
            _context.Add(pt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePT(PersonalTrainer pt)
        {
           _context.Entry(pt).Collection(x => x.Customers).IsModified = true;
            await _context.SaveChangesAsync();
        }

    }
}
