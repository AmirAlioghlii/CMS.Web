using MediatR;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Commands.Medias
{
    public class AddMediaCommand : IRequest<bool>
    {
        public IFormFile File { get; set; }
    }
}
