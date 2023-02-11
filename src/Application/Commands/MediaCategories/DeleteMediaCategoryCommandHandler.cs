using Application.Common.Interfaces.Repositories;
using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class DeleteMediaCategoryCommandHandler : IRequestHandler<DeleteMediaCategoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMediaCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            var mediaCategory = await _unitOfWork.MediaCategoryRepository.GetByIdAsync(request.MediaCategoryId);

            if (mediaCategory == null)
            {
                return false;
            }

            _unitOfWork.MediaCategoryRepository.Delete(mediaCategory);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
