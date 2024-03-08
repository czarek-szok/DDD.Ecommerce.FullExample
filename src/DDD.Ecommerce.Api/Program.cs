using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;
using DDD.Ecommerce.Infrastructure.Database;
using DDD.Ecommerce.Infrastructure.Database.Context;

namespace DDD.Ecommerce.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var command = args.FirstOrDefault();
            switch (command)
            {
                case "database-update":
                    new DatabaseMigrator<EcommerceContext>().Update();
                    break;
                default:
                    CreateHostBuilder(args).Build().Run();
                    break;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
