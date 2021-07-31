using Bma.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Framework.Infrastructure
{
    public class BmaCommonStartup : IBmaStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddResponseCompression();

            services.AddOptions();
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseResponseCompression();

            application.UseHttpsRedirection();

            application.UseRouting();

            application.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public int Order => 100;
    }
}