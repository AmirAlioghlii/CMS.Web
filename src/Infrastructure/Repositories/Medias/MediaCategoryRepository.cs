using Application.Common.Interfaces.Repositories.media;
using Domain.Entities.media;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Repositories.Medias
{
    public class MediaCategoryRepository : BaseRepository<MediaCategory>, IMediaCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MediaCategory?> GetByIdIncludeMediasAsync(long id)
        {
            return await _context.MediaCategories
                                 .Include(mediaCategory => mediaCategory.Medias)
                                 .FirstOrDefaultAsync(mediaCategory => mediaCategory.Id == id)
        }
    }
}
