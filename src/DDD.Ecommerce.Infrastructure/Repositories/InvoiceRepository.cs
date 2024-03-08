using DDD.Ecommerce.Core.Events.Publisher;
using DDD.Ecommerce.Core.Repository;
using DDD.Ecommerce.Domain.Invoices;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Infrastructure.Database.Context;


namespace DDD.Ecommerce.Infrastructure.Repositories
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(EcommerceContext context, IEventPublisher eventPublisher)
            : base(context, eventPublisher)
        {
        }
    }
}
