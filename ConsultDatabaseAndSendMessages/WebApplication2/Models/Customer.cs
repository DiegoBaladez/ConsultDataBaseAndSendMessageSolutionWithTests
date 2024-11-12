using DatabaseApi.Constants.Enums;

namespace DatabaseApi.Models
{
    public class Customer : People
    {
        public int CustomerNumber { get; set; }
        public ICollection<Account> Account { get; set; }
        public CustomerStatus IsActive { get; set; }
    }
}
