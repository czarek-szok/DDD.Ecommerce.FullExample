namespace DDD.Ecommerce.Domain.Orders
{
    public interface IOrderFactory
    {
        Order Create(Customer customer);
    }
}