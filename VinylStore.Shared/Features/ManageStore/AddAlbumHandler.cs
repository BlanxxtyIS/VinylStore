using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace VinylStore.Shared.Features.ManageStore
{
    public class AddAlbumHandler: IRequestHandler<AddAlbumRequest, AddAlbumRequest.Response>
    {
        private readonly HttpClient _httpClient;
        public AddAlbumHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddAlbumRequest.Response> Handle (AddAlbumRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync(AddAlbumRequest.RouteTemplate, request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var albumId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
                return new AddAlbumRequest.Response(albumId);
            } else
            {
                return new AddAlbumRequest.Response(-1);
            }
        }
    }
}
