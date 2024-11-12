namespace MessagesApi.Exceptions
{
    public class JsonSerializationException : Exception
    {
        public JsonSerializationException(string message) : base(message) { }
    }
}
