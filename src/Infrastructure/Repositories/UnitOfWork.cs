using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Repositories.media;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IMediaRepository MediaRepository { get; }
    public IMediaCategoryRepository MediaCategoryRepository { get; }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}