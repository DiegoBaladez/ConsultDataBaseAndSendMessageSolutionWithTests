using MessagesApi.DTO.External;
using System.Text.Json.Serialization;

namespace MessagesApi.DTO
{
    [Serializable]
    public class CustomerTransactionsRequest
    {
        [JsonPropertyName("name")]
        public string CustomerName { get; set; }
        [JsonPropertyName("document")]
        public string Doc { get; set; }
        [JsonPropertyName("entrys")]
        public List<Entry> Entrys { get; set; }
    }
}
