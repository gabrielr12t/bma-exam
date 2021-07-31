using System.Collections.Generic;
using System.Threading.Tasks;
using Bma.Core.Domain.Users;

namespace Bma.Services.Users
{
    public interface IUserService
    {
        Task InsertAsync(IList<User> users);

        Task<IList<User>> GetFilterUsersAsync(int minAge = int.MinValue, int maxAge = int.MaxValue);
    }
}