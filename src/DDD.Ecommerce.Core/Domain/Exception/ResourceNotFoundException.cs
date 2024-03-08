namespace DDD.Ecommerce.Core.Domain.Exception
{
    public class ResourceNotFoundException : System.Exception
    {
        public string ErrorMessage { get; }

        public ResourceNotFoundException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
