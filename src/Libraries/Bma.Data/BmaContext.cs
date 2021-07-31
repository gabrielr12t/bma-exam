using System.Reflection;
using Bma.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bma.Data
{
    public class BmaContext : DbContext
    {
        #region Ctor

        public BmaContext(DbContextOptions<BmaContext> options)
          : base(options) { }

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

        #endregion
    }
}