using System;
using Bma.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddBmaMediatR();
            services.AddControllers();
            services.AddResponseCompression();
            services.AddOptions();

            services.RegisterDI();
            services.RegisterSqlServer(configuration);
        }

        private static void AddBmaMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Bma.Application");
            services.AddMediatR(assembly);
        }
    }
}