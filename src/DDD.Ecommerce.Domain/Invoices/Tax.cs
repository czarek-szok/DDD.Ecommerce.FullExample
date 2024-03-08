
using DDD.Ecommerce.Core;

namespace DDD.Ecommerce.Domain.Invoices
{
    public class Tax
    {
        public double Amount { get; private set; }
        public string Description { get; private set; }

        public Tax(double amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}
