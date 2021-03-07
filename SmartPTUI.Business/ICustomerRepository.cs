using SmartPTUI.Data.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartPTUI.Business
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}