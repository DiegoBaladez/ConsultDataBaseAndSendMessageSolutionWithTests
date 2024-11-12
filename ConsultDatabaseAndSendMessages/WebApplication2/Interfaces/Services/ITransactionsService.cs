using DatabaseApi.DTO;

namespace DatabaseApi.Interfaces.Services
{
    public interface ITransactionsService
    {
        Task<CustomerTransactionsResponse> GetCustomerTransactions(long accountNumber);
    }
}
