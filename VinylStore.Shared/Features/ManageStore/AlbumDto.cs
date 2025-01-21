using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace VinylStore.Shared.Features.ManageStore
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public int TimeInMinutes { get; set; }
        public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";
        public int Rating { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public class Song
        {
            public string Name { get; set; } = string.Empty;
            public string Text { get; set; } = string.Empty;
        }
    }

    public class AlbumValidator: AbstractValidator<AlbumDto>
    {
        public AlbumValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Please enter a author name");
            RuleFor(x => x.TimeInMinutes).NotEmpty().WithMessage("Please enter a time in minutes");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Please enter a rating");
            RuleForEach(x => x.Songs).SetValidator(new SongValidator());
        }
    }

    public class SongValidator: AbstractValidator<AlbumDto.Song>
    {
        public SongValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Text).NotEmpty().WithMessage("Please enter a text");
        }
    }
}
