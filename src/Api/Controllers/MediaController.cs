using CMS.Application.Commands.Medias;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.Api.Controllers
{
    [Authorize]
    public class MediaController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add(IFormFile file)
        {
            return await _mediator.Send(new AddMediaCommand(file))
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            return await _mediator.Send(new DeleteMediaCommand(id))
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add(IFormFile file)
        {
            return await _mediator.Send(new AddMediaCommand(file))
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
