using MessagesApi.Constants.Enums;
using MessagesApi.Exceptions;
using MessagesApi.Interfaces;

namespace MessagesApi.Services
{
    public static class GenerateMessageFactoryService
    {
        public static GenerateMessageService GetMessageGenerator(MessageType type)
        {
            switch (type)
            {
                case MessageType.Statement:
                    return new GenerateStatementService();
                    break;
                default:
                    throw new NoTypeMatchException(Constants.Logs.ErrorMessages.NoTypeMatch);
                    break;
            }
            
        }
    }
}
