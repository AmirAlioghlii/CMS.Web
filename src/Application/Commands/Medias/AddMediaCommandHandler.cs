using Application.Common.Interfaces.Repositories;
using Domain.Entities.media;
using MediatR;

namespace CMS.Application.Commands.Medias
{
    public class AddMediaCommandHandler : IRequestHandler<AddMediaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMediaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddMediaCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null || request.File.Length == 0)
            {
                return false;
            }

            var path = Path.Combine(
                  Directory.GetCurrentDirectory(), "wwwroot", "medias", Guid.NewGuid().ToString());

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            _unitOfWork.MediaRepository
                .Add(new Media(path, string.Empty, string.Empty, string.Empty));

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
