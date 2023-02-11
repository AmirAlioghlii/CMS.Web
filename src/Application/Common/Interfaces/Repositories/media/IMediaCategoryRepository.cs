using Domain.Entities.media;

namespace Application.Common.Interfaces.Repositories.media;

public interface IMediaCategoryRepository : IBaseRepository<MediaCategory>
{
    Task<MediaCategory?> GetByIdIncludeMediasAsync(long id);
}