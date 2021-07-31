using System.Data;
using Bma.Core.Infrastructure;
using Bma.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Data
{
    public class SqlServerStartup : IBmaStartup
    {
        private IDbConnection Connection;
        
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public int Order => 10;
    }
}