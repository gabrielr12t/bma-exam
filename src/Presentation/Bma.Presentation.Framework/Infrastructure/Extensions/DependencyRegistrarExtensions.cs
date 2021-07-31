using Bma.Services.Installation;
using Bma.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class DependencyRegistrar
    {
        public static void RegisterDI(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInstallFakeDataService, InstallFakeDataService>();
        }
    }
}