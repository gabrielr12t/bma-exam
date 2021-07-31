using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bma.Core.Domain;

namespace Bma.Data.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        #region Insert

        Task InsertAsync(IList<TEntity> entities);
            
        #endregion

        #region Tables

        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}