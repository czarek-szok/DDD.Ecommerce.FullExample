using DDD.Ecommerce.Core.Domain;
using DDD.Ecommerce.Domain.Orders;
using System.Collections.Generic;

namespace DDD.Ecommerce.Domain.Invoices
{
    public class Invoice : AggregateRoot
    {
        public List<InvoiceLine> Lines { get; private set; }
        public Customer Customer { get; private set; }
        public double NettPrice { get; private set; }
        public double GrossPrice { get; private set; }


        public Invoice(Customer customer)
        {
            Customer = customer;
            Lines = new List<InvoiceLine>();
        }

        public Invoice() { }
        public void AddLine(InvoiceLine line)
        {
            Lines.Add(line);
            NettPrice += line.NettPrice;
            GrossPrice += line.GrossPrice;
        }
    }
}
