using Domain.Entities.media;

namespace Application.Common.Interfaces.Repositories.media;

public interface IMediaRepository : IBaseRepository<Media>
{
    Task<IEnumerable<Media>> GetByIdsAsync(IEnumerable<long> ids);
}