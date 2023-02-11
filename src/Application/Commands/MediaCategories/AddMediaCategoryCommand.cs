using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class AddMediaCategoryCommand : IRequest<bool>
    {
        public AddMediaCategoryCommand(string title, IEnumerable<long> mediaIds)
        {
            Title = title;
            MediaIds = mediaIds;
        }

        public string Title { get; set; }

        public IEnumerable<long> MediaIds { get; set; }
    }
}
