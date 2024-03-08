using DDD.Ecommerce.Domain.Invoices.TaxPolicy;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Domain.Orders.Exceptions;

namespace DDD.Ecommerce.Domain.Invoices
{
    public class InvoiceService
    {
        public Invoice CreateInvoice(Order order, ITaxPolicy taxPolicy)
        {
            if (!order.IsAccepted())
                throw new OrderNotAcceptedException(order.Id);

            Invoice invoice = new Invoice(order.Customer);

            foreach (var orderLine in order.OrderLines)
            {
                Tax tax = taxPolicy.CalculateTax(orderLine.Product, orderLine.TotalPriceWithDiscount);
                InvoiceLine line = new InvoiceLine(orderLine.Product, orderLine.Quantity, orderLine.TotalPriceWithDiscount, tax);

                invoice.AddLine(line);
            }

            return invoice;
        }
    }
}
