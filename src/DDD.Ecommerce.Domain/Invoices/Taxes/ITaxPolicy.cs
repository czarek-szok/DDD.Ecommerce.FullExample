using DDD.Ecommerce.Domain.Orders;

namespace DDD.Ecommerce.Domain.Invoices.TaxPolicy
{
    public interface ITaxPolicy
    {
        Tax CalculateTax(Product product, double price);
    }
}
