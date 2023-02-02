using Application.Common.Interfaces.Repositories;
using CMS.Application.Common.Exceptions;
using Domain.Entities.media;
using MediatR;

namespace CMS.Application.Queries.Medias
{
    public class GetMediaQueryHandler : IRequestHandler<GetMediaQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMediaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> Handle(GetMediaQuery request, CancellationToken cancellationToken)
        {
            var memory = new MemoryStream();

            var media = await _unitOfWork.MediaRepository.GetByIdAsync(request.MediaId);

            if (media == null)
            {
                throw new NotFoundException(nameof(Media), request.MediaId);
            }

            using (var stream = new FileStream(media.Url, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            return memory.ToArray();
        }
    }
}
