using System.Reflection;
using Bma.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bma.Data
{
    public class BmaContext : DbContext
    {
        #region Fields

        private readonly IConfiguration _configuration;

        #endregion

        #region Ctor

        public BmaContext(
            DbContextOptions<BmaContext> options,
            IConfiguration configuration)
          : base(options)
        {
            _configuration = configuration;
        }

        #endregion

        #region Users

        public DbSet<User> Users { get; set; }

        #endregion

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .EnableSensitiveDataLogging(true)
                    .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        #endregion
    }
}