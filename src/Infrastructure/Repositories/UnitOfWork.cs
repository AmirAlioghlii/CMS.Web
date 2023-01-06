using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Repositories.media;
using CMS.Infrastructure.Repositories.Medias;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Repositories

    private IMediaRepository mediaRepository;
    public IMediaRepository MediaRepository => mediaRepository ?? new MediaRepository(_context);

    private IMediaCategoryRepository mediaCategoryRepository;
    public IMediaCategoryRepository MediaCategoryRepository => mediaCategoryRepository ?? new MediaCategoryRepository(_context);

    #endregion

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}