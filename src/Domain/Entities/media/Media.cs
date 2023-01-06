namespace Domain.Entities.media;

public class Media : BaseAuditableEntity
{
    public Media(string url, 
        string title, 
        string? alt, 
        string? description, 
        long mediaCategoryId, 
        MediaCategory mediaCategory)
    {
        Url = url;
        Title = title;
        Alt = alt;
        Description = description;
        MediaCategoryId = mediaCategoryId;
        MediaCategory = mediaCategory;
    }

    public string Url { get; set; }

    public string Title { get; set; }

    public string? Alt { get; set; }

    public string? Description { get; set; }

    public long MediaCategoryId { get; set; }
    public MediaCategory MediaCategory { get; set; }
}