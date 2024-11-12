using MessagesApi.DTO;

namespace MessagesApi.Interfaces.External
{
    public interface IDatabaseApi
    {
        Task<CustomerTransactionsRequest> GetCustomerTransactions(long accountNumber);
    }
}
