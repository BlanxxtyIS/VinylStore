using MediatR;
using System.Net.Http.Json;
using VinylStore.Shared.Features.ManageStore;

namespace VinylStore.Client.Features.ManageStore
{
    public class AddAlbumHandler : IRequestHandler<AddAlbumRequest, AddAlbumRequest.Response>
    {
        private readonly HttpClient _httpClient;

        public AddAlbumHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddAlbumRequest.Response> Handle(AddAlbumRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync(AddAlbumRequest.RouteTemplate, request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var albumId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
                return new AddAlbumRequest.Response(albumId);
            }
            else
            {
                return new AddAlbumRequest.Response(-1);
            }
        }
    }
}
