using DatabaseApi.DTO;
using DatabaseApi.Models;

namespace DatabaseApi.Interfaces.Repository
{
    public interface ITransactionsRepository
    {
        Task<CustomerIdentification> GetCustomerByAccount(long accountNumber);
        Task<List<Entry>> GetAccountEntries(long accountNumber);
    }
}
