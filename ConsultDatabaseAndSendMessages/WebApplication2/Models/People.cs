namespace DatabaseApi.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Telephone> Telephone { get; set; }
        public ICollection<Address> Address { get; set; }
        public string Document { get; set; }
    }
}
