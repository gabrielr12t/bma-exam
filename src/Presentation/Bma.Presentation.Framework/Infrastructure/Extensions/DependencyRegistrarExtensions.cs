using Bma.Services.Installation;
using Bma.Services.Persons;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class DependencyRegistrar
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IInstallFakeDataService, InstallFakeDataService>();
        }
    }
}