using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Medias
{
    public class DeleteMediaCommand : IRequest<bool>
    {
        public DeleteMediaCommand(long mediaId)
        {
            MediaId = mediaId;
        }

        public long MediaId { get; set; }
    }
}
