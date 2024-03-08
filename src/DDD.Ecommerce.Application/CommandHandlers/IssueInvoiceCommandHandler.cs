
using DDD.Ecommerce.Core.Cqrs.Commands;
using DDD.Ecommerce.Domain.Invoices;
using DDD.Ecommerce.Domain.Invoices.TaxPolicy;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Interfaces.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Ecommerce.Application.CommandHandlers
{
    public class IssueInvoiceCommandHandler : ICommandHandler<IssueInvoiceCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceService _invoiceService;
        private readonly TaxPolicyFactory _taxPolicyFactory;

        public IssueInvoiceCommandHandler(IOrderRepository orderRepository,
                                          IInvoiceRepository invoiceRepository,
                                          InvoiceService invoiceService,
                                          TaxPolicyFactory taxPolicyFactory)
        {
            _orderRepository = orderRepository;
            _invoiceService = invoiceService;
            _invoiceRepository = invoiceRepository;
            _taxPolicyFactory = taxPolicyFactory;
        }


        public async Task HandleAsync(IssueInvoiceCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(command.OrderId, cancellationToken);

            var taxPolicy = _taxPolicyFactory.CreateTaxPolicy(order.Customer);

            var invoice = _invoiceService.CreateInvoice(order, taxPolicy);

            await _invoiceRepository.CreateAsync(invoice, cancellationToken);
        }
    }
}
