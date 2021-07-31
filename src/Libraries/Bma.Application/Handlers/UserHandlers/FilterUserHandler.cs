using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bma.Application.Queries.UserQueries;
using Bma.Application.Responses.UserResponses;
using Bma.Services.Users;
using MediatR;

namespace Bma.Application.Handlers.UserHandlers
{
    public class FilterUserHandler : IRequestHandler<FilterUserQuery, IEnumerable<UserResponse>>
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public FilterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<UserResponse>> Handle(FilterUserQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var entities = await _userService.GetFilterUsersAsync(request.MinAge, request.MaxAge);

            return entities.ToResponse();
        }

        #endregion
    }
}