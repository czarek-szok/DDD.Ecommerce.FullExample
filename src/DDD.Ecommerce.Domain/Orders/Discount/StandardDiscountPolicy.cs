namespace DDD.Ecommerce.Domain.Orders.Policies.Discount
{
    public class StandardDiscountPolicy : IDiscountPolicy
    {
        private readonly double _discount;
        private readonly double _minimumQuantity;
        public StandardDiscountPolicy(int minimumQuantity, double discount)
        {
            _discount = discount / 100;
            _minimumQuantity = minimumQuantity;
        }

        public double Calculate(double price, int quantity)
        {
            if(quantity >= _minimumQuantity)
            {
                return price * quantity * _discount;
            }
            return price * quantity;
        }
    }
}

