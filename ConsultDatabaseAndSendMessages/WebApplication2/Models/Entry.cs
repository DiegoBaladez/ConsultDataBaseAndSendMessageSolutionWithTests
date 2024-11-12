using DatabaseApi.Constants.Enums;
using System.Text.Json.Serialization;

namespace DatabaseApi.Models
{
    public class Entry
    {
        [JsonIgnore]
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DebitCreditIndicator DebitCreditIndicator { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        [JsonIgnore]
        public int CustomerNumber { get; set; }
    }
}
