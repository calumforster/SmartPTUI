using SmartPTUI.Data;
using System.Threading.Tasks;

namespace SmartPTUI.Business.Transactions
{
    public interface ICustomerTransactions
    {
        public Task SaveCustomer(Customer customer);
        public Task<Customer> UpdateCustomer(Customer customer);

        public Task<Customer> GetCustomerViaEmail(string customerEmail);
        public Task SavePT(PersonalTrainer pt);
    }
}