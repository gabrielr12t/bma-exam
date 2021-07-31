using Bma.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace Bma.Presentation.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }
    }
}