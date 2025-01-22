using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace VinylStore.Shared.Features.ManageStore
{
    public record AddAlbumRequest(AlbumDto Album) : IRequest<AddAlbumRequest.Response>
    {
        public const string RouteTemplate = "/api/albums";
        public record Response(int AlbumId);
    }

    public class AddAlbumRequestValidator: AbstractValidator<AddAlbumRequest>
    {
        public AddAlbumRequestValidator()
        {
            RuleFor(x => x.Album).SetValidator(new AlbumValidator());
        }
    }
}
