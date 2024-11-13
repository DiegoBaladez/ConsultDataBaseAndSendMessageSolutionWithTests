using MessagesApi.Constants.Enums;
using MessagesApi.DTO.Messages;
using MessagesApi.Interfaces;
using MessagesApi.Interfaces.External;

namespace MessagesApi.Services
{
    public class SendMessages : ISendMessages
    {
        private readonly IDatabaseApi _databaseApi;

        public SendMessages(IDatabaseApi databaseApi)
        {
            _databaseApi = databaseApi;
        }

        public async Task<string> SendBankToCustomerMessages(long accountNumber, MessageType messageType)
        {
            var messageGenerator = GenerateMessageFactoryService.GetMessageGenerator(messageType);

            var xmlMessage =  messageGenerator.GenerateMessage(await _databaseApi.GetCustomerTransactions(accountNumber));

            return MessagesSerializer<BussinesMessage>.Serialize(xmlMessage);
        }
    }
}
