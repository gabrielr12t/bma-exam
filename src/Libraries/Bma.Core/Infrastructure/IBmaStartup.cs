using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Core.Infrastructure
{
    public interface IBmaStartup
    {
        void ConfigureServices(IServiceCollection services1, IConfiguration configuration);

        void Configure(IApplicationBuilder application);

        int Order { get; }
    }
}