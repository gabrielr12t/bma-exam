using System.Collections.Generic;
using System.Threading.Tasks;
using Bma.Core.Domain.Persons;

namespace Bma.Services.Persons
{
    public interface IPersonService
    {
        #region Crud Operations

        Task InsertAsync(Person person);

        Task InsertAsync(IList<Person> persons);

        Task UpdateAsync(Person person);

        Task DeleteAsync(Person person);

        #endregion

        #region Queries

        Task<IList<Person>> FilterAsync(int minAge = int.MinValue, int maxAge = int.MaxValue);

        Task<Person> GetByIdAsync(int id);
            
        #endregion
    }
}