using Application.Common.Interfaces.Repositories;
using AutoMapper;
using CMS.Application.Common.Exceptions;
using CMS.Application.Queries.MediaCategories.ViewModels;
using CMS.Application.Queries.Medias;
using Domain.Entities.media;
using MediatR;

namespace CMS.Application.Queries.MediaCategories
{
    public class GetMediaCategoryQueryHandler : IRequestHandler<GetMediaCategoryQuery, MediaCategoryViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMediaCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MediaCategoryViewModel> Handle(GetMediaCategoryQuery request, CancellationToken cancellationToken)
        {
            var mediaCategory = await _unitOfWork.MediaCategoryRepository.GetByIdIncludeMediasAsync(request.MediaCategoryId);

            if (mediaCategory == null)
            {
                return null;
            }

            return _mapper.Map<MediaCategoryViewModel>(mediaCategory);
        }
    }
}
