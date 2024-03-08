using DDD.Ecommerce.Domain.Orders;
using System;

namespace DDD.Ecommerce.Domain.Invoices
{
    public class InvoiceLine
    {
        public Guid Id { get; private set; }
        public Product Product { get; }
        public int Quantity { get; }
        public double NettPrice { get; }
        public double GrossPrice { get; }
        public Tax Tax { get; }

        public InvoiceLine(Product product, int quantity, double nettPrice, Tax tax)
        {
            Id = new Guid();
            Product = product;
            Quantity = quantity;
            NettPrice = nettPrice;
            Tax = tax;
            GrossPrice = nettPrice + tax.Amount;
        }

        public InvoiceLine()
        {
        }
    }
}
