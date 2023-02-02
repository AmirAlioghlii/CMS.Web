using Application.Common.Interfaces.Repositories;
using CMS.Application.Common.Exceptions;
using Domain.Entities.media;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Commands.Medias
{
    public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMediaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
        {
            var media = await _unitOfWork.MediaRepository.GetByIdAsync(request.MediaId);

            if (media == null)
            {
                throw new NotFoundException(nameof(Media), request.MediaId);
            }

            if (File.Exists(media.Url))
            {
                File.Delete(media.Url);
            }

            _unitOfWork.MediaRepository.Delete(media);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
