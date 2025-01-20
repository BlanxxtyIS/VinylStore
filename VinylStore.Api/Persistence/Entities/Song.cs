using System.ComponentModel.DataAnnotations;

namespace VinylStore.Api.Persistence.Entities
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
        public Album Album { get; set; } = new Album();
    }
}
