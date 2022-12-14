using Application.Common.Interfaces.Repositories.media;

namespace Application.Common.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IMediaRepository MediaRepository { get; }

    public IMediaCategoryRepository MediaCategoryRepository { get; }

    public Task SaveChangesAsync();
}