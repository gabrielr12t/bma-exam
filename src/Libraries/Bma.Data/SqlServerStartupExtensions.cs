using System.Data;
using Bma.Data.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Data
{
    public static class SqlServerStartupExtensions
    {
        private static IDbConnection Connection;

        public static void RegisterSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            services
              .AddEntityFrameworkSqlServer()
              .AddDbContext<BmaContext>(ConfigureOptionsContext);
        }

        private static void ConfigureOptionsContext(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection?.ConnectionString, sqloptions => sqloptions.CommandTimeout(20));
        }
    }
}