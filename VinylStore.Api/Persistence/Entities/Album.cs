using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VinylStore.Client.Features.Home;

namespace VinylStore.Api.Persistence.Entities
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Required]
        public string AuthorName { get; set; } = string.Empty;
        [Required]
        public int TimeInMinutes { get; set; }
        public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
        [Required]
        public int Rating { get; set; }
        public IEnumerable<Song> Songs { get; set; } = new List<Song>();
    }
}
