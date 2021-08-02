using System.Threading.Tasks;
using Bma.Application.Commands.Persons;
using Bma.Application.Queries.PersonQueries;
using Bma.Presentation.Framework.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bma.Presentation.Api.Controllers
{
    [Route("/persons")]
    public class PersonController : BaseController
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Actions

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] PersonUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PersonDeleteCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromQuery] PersonFilterQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Filter(int id)
        {
            var query = new PersonFilterById() { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        #endregion
    }
}