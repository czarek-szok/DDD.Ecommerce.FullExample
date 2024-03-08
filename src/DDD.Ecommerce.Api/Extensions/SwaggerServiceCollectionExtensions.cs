using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace DDD.Ecommerce.Api.Extensions
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD.Ecommerce.Api", Version = "v1" });
                c.AddFluentValidationRules();
            });
        }
    }
}
