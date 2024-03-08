using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using DDD.Ecommerce.Core.Configuration;
using DDD.Ecommerce.Core.Exceptions;

namespace DDD.Ecommerce.Infrastructure.Database
{
    public class DatabaseMigrator<TContext> where TContext : DbContext
    {
        public void Update()
        {
            var configuration = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .Build();

            var databaseOptions = configuration.GetSection("Database").Get<SqlServerDatabaseOptions>();
            if (databaseOptions == null)
            {
                throw new AdvisoryOnboardingException("No Database configuration found. Check environment variables");
            }

            var connectionString = databaseOptions.DDLConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new AdvisoryOnboardingException("Could not build connection string for database schema update. Check environment variables with Database__ prefix");
            }

            using (var context = CreateDbContext(connectionString))
            {
                context.Database.Migrate();
            }
        }

        private static TContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var contextInstance = Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
            if (contextInstance == null)
            {
                throw new AdvisoryOnboardingException("Could not create db context");
            }

            return (TContext)contextInstance;
        }
    }
}
