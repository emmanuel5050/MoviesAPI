using MoviesAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.DatabaseContext
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
