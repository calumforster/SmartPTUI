using SmartPTUI.Data;
using System.Threading.Tasks;

namespace SmartPTUI.Business.Transactions
{
    public interface ICustomerTransactions
    {
        Task SaveCustomer(Customer customer);
    }
}