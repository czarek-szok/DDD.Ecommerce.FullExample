using DDD.Ecommerce.Domain.Orders.Policies.Discount;
using System;

namespace DDD.Ecommerce.Domain.Orders
{
    public class OrderLine
    {
        public Guid Id { get; private set; }
        public int Quantity { get; private set; }
        public Product Product { get; private set; }
        public double TotalPrice { get; private set; }
        public double TotalPriceWithDiscount { get; private set; }

        public OrderLine(Product product, int quantity, IDiscountPolicy discountPolicy)
        {
            Id = new Guid();
            Quantity = quantity;
            Product = product;
            CalculatePrice(discountPolicy);
        }

        public OrderLine() { }

        public void IncreaseQuantity(int quantity, IDiscountPolicy discountPolicy)
        {
            Quantity += quantity;
            CalculatePrice(discountPolicy);
        }

        private void CalculatePrice(IDiscountPolicy discountPolicy)
        {
            TotalPrice = Product.Price * Quantity;

            if (IsDiscountApplied(discountPolicy))
            {
                var discount = discountPolicy.Calculate(Product.Price, Quantity);
                TotalPriceWithDiscount = TotalPrice - discount;
            }
            else
            {
                TotalPriceWithDiscount = TotalPrice;
            }
        }

        private bool IsDiscountApplied(IDiscountPolicy discountPolicy)
        {
            return discountPolicy != null;
        }
    }
}
