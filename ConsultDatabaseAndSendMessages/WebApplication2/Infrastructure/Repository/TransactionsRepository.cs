using DatabaseApi.Constants.Enums;
using DatabaseApi.DTO;
using DatabaseApi.Infrastructure.DataBaseContext;
using DatabaseApi.Interfaces.Repository;
using DatabaseApi.Models;

namespace DatabaseApi.Infrastructure.Repository
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly TransactionsContext _context;

        public TransactionsRepository(TransactionsContext context)
        {
            _context = context;
        }

        public async Task<CustomerIdentification> GetCustomerByAccount(long accountNumber)
        {
            var teste = Environment.GetEnvironmentVariable("CONECTION_STRING");

            var customerId = from acc in _context.Account
                        join customer in _context.Customer on acc.CustomerNumber equals customer.CustomerNumber
                        where acc.AccountNumber == accountNumber && customer.IsActive == CustomerStatus.Active
                        select new CustomerIdentification
                        {
                            Name = customer.Name,
                            Document = customer.Document,
                            CustomerNumber = customer.CustomerNumber,
                        };

            return customerId.ToList().First();
        }
        public async Task<List<Entry>> GetAccountEntries(long accountNumber)
        {
            var query = from acc in _context.Account
                        join entry in _context.Entrys on acc.CustomerNumber equals entry.CustomerNumber
                        where acc.AccountNumber == accountNumber
                        select new Entry
                        {
                            Id = entry.Id,
                            Amount= entry.Amount,
                            Description= entry.Description,
                            Date= entry.Date,
                            DebitCreditIndicator= entry.DebitCreditIndicator,
                            Account = entry.Account,
                            CustomerNumber= entry.CustomerNumber,
                        };

            return query.ToList();
        }
    }
}

