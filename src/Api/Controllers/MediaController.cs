using CMS.Application.Commands.Medias;
using CMS.Application.Queries.Medias;
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
        public async Task<IActionResult> Add(AddMediaCommand command)
        {
            return await _mediator.Send(command)
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(DeleteMediaCommand command)
        {
            return await _mediator.Send(command)
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(GetMediaQuery query)
        {
            return File(await _mediator.Send(query), "application/octet-stream");
        }
    }
}
