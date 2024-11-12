using DatabaseApi.DTO;
using DatabaseApi.Interfaces.Repository;
using DatabaseApi.Interfaces.Services;
using System.Text.Json;

namespace DatabaseApi.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionsService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<CustomerTransactionsResponse> GetCustomerTransactions(long accountNumber)
        {
            var customerResponse = new CustomerTransactionsResponse(
                await _transactionsRepository.GetCustomerByAccount(accountNumber),
                await _transactionsRepository.GetAccountEntries(accountNumber));

            return customerResponse;
        }
    }
}
