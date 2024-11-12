using MessagesApi.Exceptions;
using MessagesApi.Interfaces;

namespace MessagesApi.Services
{
    public class SimpleHttpClient : ISimpleHttpClient
    {
        public async Task<string> Get(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                return  await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new RequestFailedException(Constants.Logs.ErrorMessages.RequestFail);
            }
        }
    }
}
