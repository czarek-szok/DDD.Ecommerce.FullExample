using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DDD.Ecommerce.Api.Extensions;
using DDD.Ecommerce.Application;
using DDD.Ecommerce.Infrastructure.Configuration;
using DDD.Ecommerce.Infrastructure.Database.Context;
using Microsoft.OpenApi.Models;
using DDD.Ecommerce.Domain;

namespace DDD.Ecommerce.Api
{
    public class Startup
    {
        private readonly ApplicationOptions _options;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = configuration.Get<ApplicationOptions>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks()
                .AddDbContextCheck<EcommerceContext>();

            services.AddVersioning();

            if (!_options.IsProduction)
            {
                services.AddSwaggerGen(c => c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme with id token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                }));
            }

            services.AddMvcCore()
                .AddFluentValidation();

            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddCoreModule();
            services.AddDomainModule();
            services.AddInfrastructureModule(_options, Configuration);
            services.AddApplicationModule();
            services.AddQueruModule();
            services.AddInterfacesModule();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks("/hc");

            if (!_options.IsProduction)
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD.Ecommerce.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c => c.WithOrigins(_options.Cors.AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
