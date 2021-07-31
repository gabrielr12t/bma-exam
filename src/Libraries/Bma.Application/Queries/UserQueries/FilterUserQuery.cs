using System.Collections.Generic;
using Bma.Application.Responses.UserResponses;
using MediatR;

namespace Bma.Application.Queries.UserQueries
{
    public class FilterUserQuery : IRequest<IEnumerable<UserResponse>>
    {
        public int MinAge { get; set; } = int.MinValue;

        public int MaxAge { get; set; } = int.MaxValue;
    }
}