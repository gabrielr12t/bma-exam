using Bma.Services.Installation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureApplication(this IApplicationBuilder application)
        {
            application.UseResponseCompression();
            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseEndpoints(endpoints => endpoints.MapControllers());
            application.InitializeDatabase();
        }

        private static async void InitializeDatabase(this IApplicationBuilder application)
        {
            var scopeFactory = application.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetService<IInstallFakeDataService>();
                await dbInitializer.InitializeDatabase();
            }
        }
    }
}