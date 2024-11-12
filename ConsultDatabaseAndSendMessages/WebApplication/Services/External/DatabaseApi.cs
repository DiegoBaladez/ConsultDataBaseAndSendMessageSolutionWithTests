using MessagesApi.DTO;
using MessagesApi.Exceptions;
using MessagesApi.Interfaces;
using MessagesApi.Interfaces.External;
using System.Text.Json;

namespace MessagesApi.Services.External
{
    public class DatabaseApi: IDatabaseApi
    {
        private readonly ISimpleHttpClient _client;
        private readonly ILogger<DatabaseApi> _logger;

        public DatabaseApi(ISimpleHttpClient client, ILogger<DatabaseApi> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<CustomerTransactionsRequest> GetCustomerTransactions(long accountNumber)
        {
           try
           {
                var jsonResult = await _client.Get(Environment.GetEnvironmentVariable("DataApi") + accountNumber);

                return JsonSerializer.Deserialize<CustomerTransactionsRequest>(jsonResult);
           }
           catch(RequestFailedException ex)
           {
                _logger.LogError("{0} | {1} | {2}",ex.Message, ex.StackTrace, DateTime.Now);
                throw;
           }
            catch(Exception ex)
            {
                _logger.LogError("{0} | {1} | {2}", ex.Message, ex.StackTrace, DateTime.Now);
                throw new JsonSerializationException(Constants.Logs.ErrorMessages.SerializationFail);
            }
        }
    }
}
