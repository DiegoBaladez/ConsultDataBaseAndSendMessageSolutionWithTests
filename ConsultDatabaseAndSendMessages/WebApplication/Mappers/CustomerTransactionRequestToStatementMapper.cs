using DatabaseApi.Constants.Enums;
using MessagesApi.DTO;
using MessagesApi.DTO.External;
using MessagesApi.DTO.Messages;

namespace MessagesApi.Mappers
{
    public static class CustomerTransactionRequestToStatementMapper
    {
        public static Statement CustomerTransactionsToStatement(this CustomerTransactionsRequest customerTransaction)
        {
            var statement = new Statement()
            {
                CustomerName = customerTransaction.CustomerName,
                Document = customerTransaction.Doc,
                Balance = FillBalance(customerTransaction.Entrys),
                Entries = customerTransaction.Entrys
            };
            return statement;
        }
        private static decimal FillBalance(ICollection<Entry> customerEntries)
        {
            decimal balance = 0;
            foreach (var entry in customerEntries)
            {
                if (entry.DebitCredit == DebitCreditIndicator.Debit) balance -= entry.Value;
                balance += entry.Value;
            }
            return balance;
        }
    }
}
