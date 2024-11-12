using DatabaseApi.Constants.Enums;
using System.ComponentModel.DataAnnotations;

namespace DatabaseApi.Models
{
    public class Telephone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public int Number { get; set; }
        public TelephoneType Type { get; set; }
        public People People { get; set; }
        public int PeopleId { get; set; }
    }
}
