﻿using System.Xml.Serialization;

namespace MessagesApi.DTO.Messages
{
    [Serializable]
    [XmlInclude(typeof(Statement))]
    public abstract class BussinesMessage
    {
        [XmlElement("MessageIdentification")]
        public Guid Id { get; set; }
    }
}
