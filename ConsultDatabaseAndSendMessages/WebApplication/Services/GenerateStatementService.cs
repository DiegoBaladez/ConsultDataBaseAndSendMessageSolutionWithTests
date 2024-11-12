using MessagesApi.DTO;
using MessagesApi.DTO.Messages;
using MessagesApi.Interfaces;
using MessagesApi.Mappers;

namespace MessagesApi.Services
{
    public class GenerateStatementService : IGenerateMessage
    {
        public string GenerateMessage(object customerInfo)
        {
            var customerTransactions = (CustomerTransactionsRequest)customerInfo;
            return XmlSerializer<Statement>.Serialize(customerTransactions.CustomerTransactionsToStatement());
        }
    }
}
