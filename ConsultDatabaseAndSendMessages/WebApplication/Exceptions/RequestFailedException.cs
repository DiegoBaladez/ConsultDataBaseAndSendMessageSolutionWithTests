namespace MessagesApi.Exceptions
{
    public class RequestFailedException : Exception
    {
        public RequestFailedException(string message) : base(message) { }
    }
}
