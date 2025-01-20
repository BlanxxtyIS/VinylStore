using Microsoft.EntityFrameworkCore;
using VinylStore.Api.Persistence.Entities;

namespace VinylStore.Api.Persistence
{
    public class VinylStoreContext: DbContext
    {
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Song> Songs => Set<Song>();

        public VinylStoreContext(DbContextOptions<VinylStoreContext> options)
            : base(options) { }
    }
}
