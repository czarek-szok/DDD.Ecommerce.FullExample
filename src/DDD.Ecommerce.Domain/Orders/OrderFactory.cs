using DDD.Ecommerce.Application.Exceptions;


namespace DDD.Ecommerce.Domain.Orders
{
    public class OrderFactory : IOrderFactory
    {
        public Order Create(Customer customer)
        {
            if (customer.IsDebtor)
                throw new CustomerIsDebtorException(customer.Id);

            Order order = new Order(customer);
            return order;
        }
    }
}
