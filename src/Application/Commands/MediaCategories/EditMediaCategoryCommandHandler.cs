using Application.Common.Interfaces.Repositories;
using Domain.Entities.media;
using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class EditMediaCategoryCommandHandler : IRequestHandler<EditMediaCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMediaCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EditMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            var mediaCategory = await _unitOfWork.MediaCategoryRepository.GetByIdIncludeMediasAsync(request.MediaCategoryId);

            if (mediaCategory == null)
            {
                return false;
            }

            var medias = await _unitOfWork.MediaRepository.GetByIdsAsync(request.MediaIds);

            if (!medias.Any())
            {
                return false;
            }

            mediaCategory.Medias.Clear();

            foreach (var media in medias)
            {
                media.MediaCategory = mediaCategory;
            }

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
