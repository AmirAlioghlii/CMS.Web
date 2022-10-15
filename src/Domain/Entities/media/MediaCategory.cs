namespace Domain.Entities.media;

public class MediaCategory
{
    public string Title { get; set; }

    public ICollection<Media> Medias { get; private set; } = new HashSet<Media>();
}