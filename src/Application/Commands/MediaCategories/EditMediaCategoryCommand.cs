using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class EditMediaCategoryCommand : IRequest<bool>
    {
        public EditMediaCategoryCommand(long mediaCategoryId, string title, IEnumerable<long> mediaIds)
        {
            MediaCategoryId = mediaCategoryId;
            Title = title;
            MediaIds = mediaIds;
        }

        public long MediaCategoryId { get; set; }

        public string Title { get; set; }

        public IEnumerable<long> MediaIds { get; set; }
    }
}
