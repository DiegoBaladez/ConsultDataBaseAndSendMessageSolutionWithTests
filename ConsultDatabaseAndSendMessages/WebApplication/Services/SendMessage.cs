using MessagesApi.Constants.Enums;
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

        public async Task<string> GetStatement(long accountNumber)
        {
            var messageGenerator = GenerateMessageFactoryService.GetMessageGenerator(MessageType.Statement);

            return messageGenerator.GenerateMessage(await _databaseApi.GetCustomerTransactions(accountNumber));
        }
    }
}
