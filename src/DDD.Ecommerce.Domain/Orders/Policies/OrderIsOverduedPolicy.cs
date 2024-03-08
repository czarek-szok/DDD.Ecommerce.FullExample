using DDD.Ecommerce.Core.Domain.Specification;
using System;

namespace DDD.Ecommerce.Domain.Orders.Specification
{
    public class OrderIsOverduedPolicy : Specification<Order>
    {
        public override SpecificationResult IsSatisfiedBy(Order entity)
        {
            var specificationResult = SpecificationResult.Satisfied();

            if (IsOverdued(entity))
            {
                specificationResult.IsSatisifed = false;
                specificationResult.Errors.Add($"Order {entity.Id} is overdued");
            }

            return specificationResult;
        }

        private bool IsOverdued(Order order)
        {
            return order.CreateDate > DateTime.Today.AddMonths(-1);
        }
    }
}
