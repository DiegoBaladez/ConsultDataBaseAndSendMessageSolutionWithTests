namespace MessagesApi.Interfaces
{
    public interface ISimpleHttpClient
    {
        Task<string> Get(string url);
    }
}
