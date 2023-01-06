using Application.Common.Interfaces.Repositories.media;
using Domain.Entities.media;
using Infrastructure.Persistence;

namespace CMS.Infrastructure.Repositories.Medias
{
    public class MediaCategoryRepository : BaseRepository<MediaCategory>, IMediaCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
