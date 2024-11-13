using DatabaseApi.Constants.Enums;
using MessagesApi.DTO;
using MessagesApi.DTO.External;
using MessagesApi.DTO.Messages;
using MessagesApi.Interfaces;

namespace MessagesApi.Services
{
    public class GenerateStatementService : GenerateMessageService
    {
        public override BussinesMessage GenerateMessage(object customerInfo)
        {
            var customerTransactions = (CustomerTransactionsRequest)customerInfo;
            var statement = new Statement()
            {
                CustomerName = customerTransactions.CustomerName,
                Document = customerTransactions.Doc,
                Balance = FillBalance(customerTransactions.Entrys),
                Entries = customerTransactions.Entrys
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

