using DDD.Ecommerce.Domain.Orders;

namespace DDD.Ecommerce.Domain.Invoices.TaxPolicy
{
    public class TaxPolicyFactory
    {
        public ITaxPolicy CreateTaxPolicy(Customer customer)
        {
            if (customer.IsForeigner)
                return new ForeignerTaxPolicy();

            return new StandardTaxPolicy();
        }
    }
}
