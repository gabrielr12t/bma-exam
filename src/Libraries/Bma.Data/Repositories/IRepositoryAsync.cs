using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bma.Core.Domain;

namespace Bma.Data.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        #region Get

        Task<TEntity> GetByIdAsync(int id);
            
        #endregion

        #region Insert

         Task InsertAsync(TEntity entity);

        Task InsertAsync(IList<TEntity> entities);

        #endregion

        #region Update

        Task UpdateAsync(TEntity entity);

        #endregion

        #region Delete

        Task DeleteAsync(TEntity entity);

        #endregion

        #region Tables

        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}