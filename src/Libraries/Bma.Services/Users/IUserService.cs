using System.Collections.Generic;
using System.Threading.Tasks;
using Bma.Core.Domain.Users;

namespace Bma.Services.Users
{
    public interface IUserService
    {
        Task<IList<User>> GetUsersAsync();
    }
}