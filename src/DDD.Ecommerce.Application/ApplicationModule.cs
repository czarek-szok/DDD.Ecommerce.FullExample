using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Core.Extensions;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Domain.Orders.Policies.Discount;
using DDD.Ecommerce.Domain.Invoices.TaxPolicy;
using DDD.Ecommerce.Domain.Invoices;

namespace DDD.Ecommerce.Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            var thisAssembly = typeof(ApplicationModule).Assembly;

            services.AddCommandHandlers(thisAssembly);
        }

        public static void AddDomainModule(this IServiceCollection services)
        {
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<IDiscountPolicyFactory, DiscountPolicyFactory>();
            services.AddScoped<TaxPolicyFactory>();
            services.AddScoped<InvoiceService>();

        }
    }
}
