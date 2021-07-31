using Bma.Core.Infrastructure;
using Bma.Presentation.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Presentation.Api
{
    public class Startup
    {
        private IEngine _engine;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _engine = services.ConfigureApplicationServices(Configuration);
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
           application.ConfigureRequestPipeline();
        }
    }
}
