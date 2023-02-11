using Application.Common.Interfaces.Repositories.media;
using Domain.Entities.media;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.Medias
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetByIdsAsync(IEnumerable<long> ids)
        {
            return await _context.Medias.Where(media => ids.Contains(media.Id)).ToListAsync();
        }
    }
}
