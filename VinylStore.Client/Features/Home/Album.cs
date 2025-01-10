﻿namespace VinylStore.Client.Features.Home
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public int TimeInMinutes { get; set; }
        public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
        public int Rating { get; set; }
        public IEnumerable<Song> Songs { get; set; } = new List<Song>();
    }
}
