using Application.Common.Interfaces.Repositories.media;
using Domain.Entities.media;
using Infrastructure.Persistence;

namespace CMS.Infrastructure.Repositories.Medias
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
