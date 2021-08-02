using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bma.Application.Commands.Persons;
using Bma.Application.Queries.PersonQueries;
using Bma.Application.Responses.PersonResponses;
using Bma.Services.Persons;
using MediatR;

namespace Bma.Application.Handlers
{
    public class PersonHandler :
        IRequestHandler<PersonCreateCommand, bool>,
        IRequestHandler<PersonUpdateCommand, bool>,
        IRequestHandler<PersonDeleteCommand, bool>,
        IRequestHandler<PersonFilterQuery, IEnumerable<PersonResponse>>,
        IRequestHandler<PersonFilterById, PersonResponse>
    {
        #region Fields

        private readonly IPersonService _personService;

        #endregion

        #region Ctor

        public PersonHandler(IPersonService personService)
        {
            _personService = personService;
        }

        #endregion

        #region Crud Operations

        public async Task<bool> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
             if (request == null)
                return false;

            await _personService.InsertAsync(request.ToEntity());
            return true;
        }

        public async Task<bool> Handle(PersonUpdateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return false;

            if (request.Id == 0)
                return false;

             await _personService.UpdateAsync(request.ToEntity());
            return true;
        }

        public async Task<bool> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return false;

            if (request.Id == 0)
                return false;

            await _personService.DeleteAsync(request.ToEntity());
            return true;
        }

        #endregion

        #region Queries

        public async Task<IEnumerable<PersonResponse>> Handle(PersonFilterQuery request, CancellationToken cancellationToken)
        {
            var entities = await _personService.FilterAsync(request.MinAge, request.MaxAge);
            return entities.ToResponse();
        }

        public async Task<PersonResponse> Handle(PersonFilterById request, CancellationToken cancellationToken)
        {
             var entity = await _personService.GetByIdAsync(request.Id);
             return entity.ToResponse();
        }

        #endregion
    }
}