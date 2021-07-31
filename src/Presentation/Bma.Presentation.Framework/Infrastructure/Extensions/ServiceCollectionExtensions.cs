using System;
using Bma.Core.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEngine ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddBmaMediatR();
            services.AddControllers();
            services.AddSwagger();

            var engine = EngineContext.Create();
            engine.ConfigureServices(services, configuration);

            return engine;
        }

        public static void AddBmaMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Bma.Application");
            services.AddMediatR(assembly);
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bma.Presentation.Api", Version = "v1" }));
        }
    }
}