namespace CMS.Application.Queries.MediaCategories.ViewModels
{
    public class MediaCategoryViewModel
    {
        public MediaCategoryViewModel()
        {
        }

        public MediaCategoryViewModel(string title, IEnumerable<long> mediaIds)
        {
            Title = title;
            MediaIds = mediaIds;
        }

        public string Title { get; set; }

        public IEnumerable<long> MediaIds { get; set; }
    }
}
