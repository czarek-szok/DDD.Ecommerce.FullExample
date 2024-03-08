using DDD.Ecommerce.Core.Configuration;

namespace DDD.Ecommerce.Infrastructure.Configuration
{
    public class ApplicationOptions
    {
        public SqlServerDatabaseOptions Database { get; set; } = new SqlServerDatabaseOptions();
        public bool IsProduction { get; set; }
        public PlaygroundCarouselOptions PlaygroundCarousel { get; set; } = new PlaygroundCarouselOptions();
        public PlaygroundReportingServiceClientOptions PlaygroundReportingServiceClient { get; set; } = new PlaygroundReportingServiceClientOptions();
        public CorsOptions Cors { get; set; } = new CorsOptions();
    }
}