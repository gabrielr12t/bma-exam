using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Core.Infrastructure
{
    public class BmaEngine : IEngine
    {
        #region Utilities

        protected static IEnumerable<Assembly> GetAssemblies()
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(Assembly.GetEntryAssembly());

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);
        }

        protected IEnumerable<Type> FindClassTypeOfType<T>()
        {
            return GetAssemblies()
                    .SelectMany(p => p.GetTypes())
                    .Where(p => typeof(T).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);
        }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var startupConfigurations = FindClassTypeOfType<IBmaStartup>();

            var instances = startupConfigurations
                .Select(startup => (IBmaStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);
        }

        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            var startupConfigurations = FindClassTypeOfType<IBmaStartup>();

            var instances = startupConfigurations
                .Select(startup => (IBmaStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
                instance.Configure(application);
        }

        #endregion
    }
}