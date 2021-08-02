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

        #region Get

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await TableNoTracking.FirstOrDefaultAsync(p => p.Id == id);
        }

        #endregion

        #region Insert

        public async Task InsertAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(IList<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Update

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(await _dbset.FirstOrDefaultAsync(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            // var entry = await _context.Set<TEntity>().FirstOrDefaultAsync(p => p.Equals(entity));
            // _context.Entry(entry).CurrentValues.SetValues(entity);
            // await _context.SaveChangesAsync();
        }

        #endregion

        #region Delete

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
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