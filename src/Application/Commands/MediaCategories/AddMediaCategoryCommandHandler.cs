using Application.Common.Interfaces.Repositories;
using Domain.Entities.media;
using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class AddMediaCategoryCommandHandler : IRequestHandler<AddMediaCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMediaCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            var medias = await _unitOfWork.MediaRepository.GetByIdsAsync(request.MediaIds);

            if (!medias.Any())
            {
                return false;
            }

            var mediaCategory = new MediaCategory(request.Title);

            _unitOfWork.MediaCategoryRepository.Add(mediaCategory);

            foreach (var media in medias)
            {
                media.MediaCategory = mediaCategory;
            }

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
