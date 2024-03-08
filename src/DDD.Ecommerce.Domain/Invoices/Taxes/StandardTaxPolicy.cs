using DDD.Ecommerce.Domain.Orders;

namespace DDD.Ecommerce.Domain.Invoices.TaxPolicy
{
    public class StandardTaxPolicy : ITaxPolicy
    {
        private double _defaultTax = 0.1;
        private double _phoneTax = 0.15;

        public Tax CalculateTax(Product product, double price)
        {
            if (product.Type == ProductType.Phone)
            {
                var phoneTaxAmount = price * _phoneTax;
                return new Tax(phoneTaxAmount, "Phone tax");
            }

            var standardTaxAmount = price * _defaultTax;
            return new Tax(standardTaxAmount, "Standard tax");
        }
    }
}

