namespace DDD.Ecommerce.Infrastructure.Configuration
{
    public class PlaygroundReportingServiceClientOptions
    {
        public string ServiceUrl { get; set; } = string.Empty;

        public bool UseFakeService { get; set; }
    }
}
