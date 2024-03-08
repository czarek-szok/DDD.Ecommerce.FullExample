namespace DDD.Ecommerce.Domain.Orders.Policies.Discount
{
    public class DiscountPolicyFactory : IDiscountPolicyFactory
    {
        private int _minQuantity = 10;
        private double _standardDiscountPercentage = 5;
        private double _vipDiscountPercentage = 10;

        public DiscountPolicyFactory()
        {
        }

        public IDiscountPolicy Create(Customer customer)
        {
            IDiscountPolicy discountPolicy;

            if (customer.IsVip)
            {
                discountPolicy = new CustomerVipDiscountPolicy(_vipDiscountPercentage);
            }
            else
            {
                discountPolicy = new StandardDiscountPolicy(_minQuantity, _standardDiscountPercentage);
            }

            return discountPolicy;
        }
    }
}
