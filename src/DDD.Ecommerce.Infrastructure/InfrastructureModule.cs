using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Infrastructure.Configuration;
using DDD.Ecommerce.Infrastructure.Database.Context;
using DDD.Ecommerce.Domain.Orders;
using DDD.Ecommerce.Infrastructure.Repositories;
using DDD.Ecommerce.Domain.Invoices;

namespace DDD.Ecommerce.Application
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructureModule(
            this IServiceCollection services,
            ApplicationOptions applicationOptions,
            IConfiguration configuration)
        {
            services.ConfigureOptions(configuration);
            services.AddDbContext<EcommerceContext>(options =>
                options.UseSqlServer(applicationOptions.Database.ConnectionString), ServiceLifetime.Singleton);

            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
            services.AddSingleton<IProductRepository, ProductReadonlyRepository>();
        }

        private static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationOptions>(configuration);
            services.Configure<PlaygroundCarouselOptions>(configuration.GetSection(nameof(ApplicationOptions.PlaygroundCarousel)));
            services.Configure<PlaygroundReportingServiceClientOptions>(configuration.GetSection(nameof(ApplicationOptions.PlaygroundReportingServiceClient)));

        }
    }
}
