using Bma.Application.Responses.PersonResponses;
using MediatR;

namespace Bma.Application.Queries.PersonQueries
{
    public class PersonFilterById : IRequest<PersonResponse>
    {
        public int Id { get; set; }
    }
}