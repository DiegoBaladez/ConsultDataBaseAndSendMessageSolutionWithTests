using MessagesApi.DTO.Messages;

namespace MessagesApi.Interfaces
{
    public interface IGenerateMessage
    {
        BussinesMessage GenerateMessage(object customerInfo);
    }
}
