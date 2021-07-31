using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bma.Core.Domain.Users;
using Bma.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bma.Services.Users
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly IRepositoryAsync<User> _userRepository;

        #endregion

        #region Ctor

        public UserService(IRepositoryAsync<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        public async Task<IList<User>> GetFilterUsersAsync(int minAge = int.MinValue, int maxAge = int.MaxValue)
        {
            var query = _userRepository.TableNoTracking;

            query = query.Where(p => p.Age >= minAge && p.Age <= maxAge);

            return await query.ToListAsync();
        }

        public async Task InsertAsync(IList<User> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            await _userRepository.InsertAsync(users);
        }

        #endregion
    }
}