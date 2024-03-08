namespace DDD.Ecommerce.Core.Domain.Exception
{
    public class DomainExceptionMessage
    {
        public string Message { get; set; } = null!;

        public object[] Arguments { get; set; } = null!;

        public DomainExceptionMessage()
        {
        }

        public DomainExceptionMessage(string message)
        {
            Message = message;
        }

        public DomainExceptionMessage(string message, params object[] args) : this(message)
        {
            Arguments = args;
        }
    }
}
