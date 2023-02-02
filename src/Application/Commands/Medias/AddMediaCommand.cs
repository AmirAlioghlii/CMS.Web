using MediatR;
using Microsoft.AspNetCore.Http;

namespace CMS.Application.Commands.Medias
{
    public class AddMediaCommand : IRequest<bool>
    {
        public AddMediaCommand(IFormFile file)
        {
            File = file;
        }

        public IFormFile File { get; set; }
    }
}
