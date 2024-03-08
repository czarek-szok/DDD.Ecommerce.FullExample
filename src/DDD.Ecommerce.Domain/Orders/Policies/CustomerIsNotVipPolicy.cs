
using DDD.Ecommerce.Core.Domain.Specification;

namespace DDD.Ecommerce.Domain.Orders.Specification
{
    public class CustomerIsNotVipPolicy : Specification<Order>
    {
        public override SpecificationResult IsSatisfiedBy(Order entity)
        {
            var specificationResult = SpecificationResult.Satisfied();

            if (!entity.Customer.IsVip)
            {
                specificationResult.IsSatisifed = false;
                specificationResult.Errors.Add($"Customer {entity.Customer.Id} is not VIP customer");
            }

            return specificationResult;
        }
    }
}
