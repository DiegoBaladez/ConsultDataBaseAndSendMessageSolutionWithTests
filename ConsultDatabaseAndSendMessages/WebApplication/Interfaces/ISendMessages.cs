using MessagesApi.Constants.Enums;

namespace MessagesApi.Interfaces
{
    public interface ISendMessages
    {
       Task<string> SendBankToCustomerMessages(long accountNumber, MessageType messageType);
    }
}
