namespace DatabaseApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public long AccountNumber { get; set; }
        public int AccountDigit { get; set; }
        public Customer Holder { get; set; }
        public int CustomerNumber { get; set; }
        public ICollection<Entry> Entrys { get; set; }
    }
}
