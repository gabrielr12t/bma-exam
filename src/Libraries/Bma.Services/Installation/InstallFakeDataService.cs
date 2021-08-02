using System;
using System.Collections.Generic;
using System.Threading.Tasks; 
using Bma.Data;
using Bma.Data.Repositories;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bma.Services.Installation
{
    public class InstallFakeDataService : IInstallFakeDataService
    {
        #region Fields

        private readonly IRepositoryAsync<Bma.Core.Domain.Persons.Person> _personRepository;
        private readonly IServiceScopeFactory _scopeFactory;
        private bool _existsDatabase = false;

        #endregion

        #region Ctor

        public InstallFakeDataService(
            IRepositoryAsync<Bma.Core.Domain.Persons.Person> personRepository,
            IServiceScopeFactory scopeFactory)
        {
            _personRepository = personRepository;
            _scopeFactory = scopeFactory;
        }

        #endregion

        #region Utilities

        protected async Task InsertPersonDataAsync()
        {
            var fakePersons = await GeneratePersons();
            await _personRepository.InsertAsync(fakePersons);
        }

        protected Task<List<Bma.Core.Domain.Persons.Person>> GeneratePersons()
        {
            var fakeData = new Faker<Bma.Core.Domain.Persons.Person>()
                .RuleFor(p => p.Name, p => p.Person.FirstName)
                .RuleFor(p => p.Age, p => p.Random.Int(1, 100))
                .RuleFor(p => p.Gender, p => p.Random.ArrayElement(new char[] { 'M', 'F' }))
                .RuleFor(p => p.Weight, p => Math.Round(p.Random.Double(50, 120), 2))
                .RuleFor(p => p.Height, p => Math.Round(p.Random.Double(1.5, 2.1), 2));

            return Task.FromResult(fakeData.Generate(15));
        }

        #endregion

        #region Methods

        public async Task InitializeDatabase()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BmaContext>())
                {
                    _existsDatabase = await context.Database.CanConnectAsync();

                    await context.Database.MigrateAsync();

                    if (!_existsDatabase)
                    {
                        await InsertPersonDataAsync();
                    }
                }
            }
        }

        #endregion
    }
}