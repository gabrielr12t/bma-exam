
using System.Threading.Tasks;
using Bma.Application.Queries.UserQueries;
using Bma.Presentation.Framework.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bma.Presentation.Api.Controllers
{
    [Route("/users")]
    public class UserController : BaseController
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> FilterUsers([FromBody] FilterUserQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        #endregion
    }
}