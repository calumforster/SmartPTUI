using Microsoft.AspNetCore.Identity;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerById(string id);
        Task SaveCustomer(Customer Customer);
        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<Customer> GetCustomerViaEmail(string email);

        public Task SavePT(PersonalTrainer pt);

        public Task<PersonalTrainer> GetPTById(int id);
        public Task<PersonalTrainer> GetPTByUserId(string id);

        public Task UpdatePT(PersonalTrainer pt);
        public Task<List<Customer>> GetAllCustomers();
        public Task UpdateCustomerAdmin(Customer customer);

        public Task<Customer> GetCustomerByDBId(int id);
    }
}