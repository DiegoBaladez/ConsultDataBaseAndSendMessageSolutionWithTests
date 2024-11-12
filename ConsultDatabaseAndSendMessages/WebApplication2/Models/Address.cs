using DatabaseApi.Constants.Enums;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public long CEP { get; set; }
        public string City { get; set; }
        public Uf Uf { get; set; }
        public int? Number { get; set; }
        public int? Floor { get; set; }
        public int? OfficeNumber { get; set; }
        public People People { get; set; }
        public int PeopleId { get; set; }
    }
}
