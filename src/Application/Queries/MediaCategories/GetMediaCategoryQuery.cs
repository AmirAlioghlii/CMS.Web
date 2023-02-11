using CMS.Application.Queries.MediaCategories.ViewModels;
using MediatR;

namespace CMS.Application.Queries.MediaCategories
{
    public class GetMediaCategoryQuery : IRequest<MediaCategoryViewModel>
    {
        public GetMediaCategoryQuery(long mediaCategoryId)
        {
            MediaCategoryId = mediaCategoryId;
        }

        public long MediaCategoryId { get; set; }
    }
}
