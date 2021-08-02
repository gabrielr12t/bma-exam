using System.Collections.Generic;
using Bma.Application.Responses.PersonResponses;
using MediatR;

namespace Bma.Application.Queries.PersonQueries
{
    public class PersonFilterQuery : IRequest<IEnumerable<PersonResponse>>
    {
        public int MinAge { get; set; } 

        public int MaxAge { get; set; } 
    }
}