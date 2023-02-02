using MediatR;

namespace CMS.Application.Queries.Medias
{
    public class GetMediaQuery : IRequest<byte[]>
    {
        public GetMediaQuery(long mediaId)
        {
            MediaId = mediaId;
        }

        public long MediaId { get; set; }
    }
}
