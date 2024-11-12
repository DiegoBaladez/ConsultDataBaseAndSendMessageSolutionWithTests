using DatabaseApi.Models;

namespace DatabaseApi.DTO
{
    public class CustomerTransactionsResponse
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public ICollection<Entry> Entrys { get; set; }

        public CustomerTransactionsResponse(CustomerIdentification customerIdentification, ICollection<Entry> entrys)
        {
            Name = customerIdentification.Name;
            Document = customerIdentification.Document;
            Entrys = entrys;
        }
    }
}
