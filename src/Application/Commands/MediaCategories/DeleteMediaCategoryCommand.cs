using MediatR;

namespace CMS.Application.Commands.MediaCategories
{
    public class DeleteMediaCategoryCommand : IRequest<bool>
    {
        public DeleteMediaCategoryCommand(long mediaCategoryId)
        {
            MediaCategoryId = mediaCategoryId;
        }

        public long MediaCategoryId { get; set; }
    }
}
