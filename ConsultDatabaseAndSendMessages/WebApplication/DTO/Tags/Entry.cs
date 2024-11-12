using DatabaseApi.Constants.Enums;
using System.Text.Json.Serialization;

namespace MessagesApi.DTO.External
{
    public class Entry
    {
        [JsonPropertyName("amount")]
        public decimal Value { get; set; }
        [JsonPropertyName("description")]
        public string Historic { get; set; }
        [JsonPropertyName("date")]
        public DateTime EntrysDate { get; set; }
        [JsonPropertyName("debitCreditIndicator")]
        public DebitCreditIndicator DebitCredit { get; set; }
    }
}
