
namespace DDD.Ecommerce.Domain.Orders.Policies.Discount
{
    public interface IDiscountPolicyFactory
    {
        IDiscountPolicy Create(Customer customer);
    }
}
