using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bma.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bma.Data.Repositories
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity>, IDisposable where TEntity : BaseEntity
    {
        #region Fiels

        private readonly BmaContext _context;
        private readonly DbSet<TEntity> _dbset;


        #endregion

        #region Ctor

        public RepositoryAsync(BmaContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        #endregion

        #region Insert

        public async Task InsertAsync(IList<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Tables

        public IQueryable<TEntity> TableNoTracking { get { return _dbset.AsNoTracking(); } }

        #endregion

        #region Dispose

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }

        #endregion
    }
}