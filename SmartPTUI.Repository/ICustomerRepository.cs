using SmartPTUI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPTUI.ContentRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerById(int id);
    }
}