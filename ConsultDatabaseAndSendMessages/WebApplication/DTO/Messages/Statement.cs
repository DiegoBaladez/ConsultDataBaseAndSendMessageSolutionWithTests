using MessagesApi.DTO.External;
using System.Xml.Serialization;

namespace MessagesApi.DTO.Messages
{
    [Serializable]
    public class Statement : BussinesMessage
    {
        [XmlElement("CustomerName")]
        public string CustomerName { get; set; }
        [XmlElement("CustomerDocument")]
        public string Document { get; set; }
        [XmlElement("CustomerBalance")]
        public decimal Balance { get; set; }
        [XmlElement("CustomerEntries")]
        public List<Entry> Entries { get; set; }
    }
}
