using CMS.Application.Commands.MediaCategories;
using CMS.Application.Queries.MediaCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.Api.Controllers
{
    [Authorize]
    public class MediaCategoryController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MediaCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Add(AddMediaCategoryCommand command)
        {
            return await _mediator.Send(command)
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Edit(EditMediaCategoryCommand command)
        {
            return await _mediator.Send(command)
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            return await _mediator.Send(new DeleteMediaCategoryCommand(id))
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(GetMediaCategoryQuery query)
        {
            var response = await _mediator.Send(query);

            return  response != null
                ? Ok(response)
                : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
