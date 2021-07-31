using System;
using Bma.Core.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IEngine ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddBmaMediatR();
            services.AddControllers();

            var engine = EngineContext.Create();
            engine.ConfigureServices(services, configuration);

            return engine;
        }

        public static void AddBmaMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Bma.Application");
            services.AddMediatR(assembly);
        }
    }
}