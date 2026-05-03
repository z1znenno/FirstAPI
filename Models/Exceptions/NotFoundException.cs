namespace FirstAPI.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message) {}
    }
}