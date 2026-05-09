namespace FirstAPI.Models.Exceptions
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string Message) : base(Message) {}
    }
}