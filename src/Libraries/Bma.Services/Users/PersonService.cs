using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bma.Core.Domain.Persons;
using Bma.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bma.Services.Persons
{
    public class PersonService : IPersonService
    {
        #region Fields

        private readonly IRepositoryAsync<Person> _personRepository;

        #endregion

        #region Ctor

        public PersonService(IRepositoryAsync<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        #region Crud Operations

        public async Task InsertAsync(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            await _personRepository.InsertAsync(person);
        }

        public async Task InsertAsync(IList<Person> persons)
        {
            if (persons == null)
                throw new ArgumentNullException(nameof(persons));

            await _personRepository.InsertAsync(persons);
        }

        public async Task UpdateAsync(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            await _personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            await _personRepository.DeleteAsync(person);
        }

        #endregion

        #region Queries

        public async Task<IList<Person>> FilterAsync(int minAge = int.MinValue, int maxAge = int.MaxValue)
        {
            var query = _personRepository.TableNoTracking;

            query = query.Where(p => p.Age >= minAge && p.Age <= maxAge);

            return await query.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            if (id == 0)
                return default;

            return await _personRepository.GetByIdAsync(id);
        }

        #endregion
    }
}