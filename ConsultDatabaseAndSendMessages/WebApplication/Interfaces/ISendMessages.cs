namespace MessagesApi.Interfaces
{
    public interface ISendMessages
    {
       Task<string> GetStatement(long accountNumber);
    }
}
