using Ardalis.ApiEndpoints;
using VinylStore.Api.Persistence;
using VinylStore.Api.Persistence.Entities;
using VinylStore.Shared.Features.ManageStore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace VinylStore.Api.Features.ManageAlbums;

public class AddAlbumEndpoints : EndpointBaseAsync.WithRequest<AddAlbumRequest>
{
    private readonly VinylStoreContext _database;

    public AddAlbumEndpoints(VinylStoreContext database)
    {
        _database = database;
    }

    [HttpPost(AddAlbumRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddAlbumRequest request, CancellationToken cancellationToken = default)
    {
        var album = new Album
        {
            Name = request.Album.Name,
            Description = request.Album.Description,
            AuthorName = request.Album.AuthorName,
            TimeInMinutes = 0,
            Rating = request.Album.Rating
        };

        await _database.Albums.AddAsync(album, cancellationToken);

        var routeInstructions = request.Album.Songs.Select(x => new Song
        {
            Name = x.Name,
            Text = x.Text,
            Album = album
        });

        await _database.Songs.AddRangeAsync(routeInstructions, cancellationToken);
        await _database.SaveChangesAsync(cancellationToken);

        return Ok(album.Id);
    }
}
