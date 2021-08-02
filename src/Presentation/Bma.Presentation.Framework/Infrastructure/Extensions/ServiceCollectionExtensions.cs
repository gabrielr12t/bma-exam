using System;
using System.Linq;
using Bma.Data;
using Bma.Presentation.Framework.Mvc.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

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
            services.AddCors();
            services.AddMvcCore();
            services.AddBmaMvc();

            services.RegisterDI();
            services.RegisterSqlServer(configuration);
        }

        private static void AddBmaMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Bma.Application");
            services.AddMediatR(assembly);
        }

        private static void AddBmaMvc(this IServiceCollection services)
        {
            IMvcBuilder mvcBuilder = services.AddMvc();

            services.AddMvc(options => options.Filters.Add(typeof(RequestValidatorAttribute)))
                    .AddFluentValidation(configuration =>
                {
                    var assemblies = mvcBuilder.PartManager.ApplicationParts
                        .OfType<AssemblyPart>()
                        .Where(part => part.Name.StartsWith("Bma", StringComparison.InvariantCultureIgnoreCase))
                        .Select(part => part.Assembly);
                    configuration.RegisterValidatorsFromAssemblies(assemblies);

                    configuration.ImplicitlyValidateChildProperties = true;
                }); 
        }
    }
}