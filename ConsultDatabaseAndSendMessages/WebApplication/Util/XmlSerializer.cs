using System.Xml;
using System.Xml.Serialization;

namespace MessagesApi.Services
{
    public static class MessagesSerializer<T> where T : class
    {
        public static string Serialize(T obj)
        {
            var teste = typeof(T);
            try
            {
                XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
                using (var sww = new StringWriter())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                    {
                        xsSubmit.Serialize(writer, obj);
                        return sww.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
