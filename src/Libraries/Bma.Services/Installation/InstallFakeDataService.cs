using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bma.Core.Domain.Users;
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

        private readonly IRepositoryAsync<User> _userRepository;
        private readonly IServiceScopeFactory _scopeFactory;
        private bool _existsDatabase = false;

        #endregion

        #region Ctor

        public InstallFakeDataService(
            IRepositoryAsync<User> userRepository,
            IServiceScopeFactory scopeFactory)
        {
            _userRepository = userRepository;
            _scopeFactory = scopeFactory;
        }

        #endregion

        #region Utilities

        protected async Task InsertUserDataAsync()
        {
            var fakeUsers = await GenerateUsers();
            await _userRepository.InsertAsync(fakeUsers);
        }

        protected Task<List<User>> GenerateUsers()
        {
            var fakeData = new Faker<User>()
                .RuleFor(p => p.Name, p => p.Person.FirstName)
                .RuleFor(p => p.Age, p => p.Random.Int(1, 100))
                .RuleFor(p => p.Gender, p => p.Random.ArrayElement(new char[] { 'M', 'F' }))
                .RuleFor(p => p.Weight, p => Math.Round(p.Random.Double(50, 120), 2))
                .RuleFor(p => p.Height, p => Math.Round(p.Random.Double(1.5, 2.1), 2))
                .RuleFor(p => p.IsOldMan, (f, u) => u.Age >= 60);

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
                        await InsertUserDataAsync();
                    }
                }
            }
        }

        #endregion
    }
}