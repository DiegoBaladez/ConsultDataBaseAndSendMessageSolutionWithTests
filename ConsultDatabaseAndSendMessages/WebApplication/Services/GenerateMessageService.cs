using MessagesApi.DTO.Messages;

namespace MessagesApi.Services
{
    public abstract class GenerateMessageService
    {
        public abstract BussinesMessage GenerateMessage(object data);
    }
}
