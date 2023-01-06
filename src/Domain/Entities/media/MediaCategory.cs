namespace Domain.Entities.media;

public class MediaCategory: BaseAuditableEntity
{

    public MediaCategory(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public ICollection<Media> Medias { get; private set; } = new HashSet<Media>();
}