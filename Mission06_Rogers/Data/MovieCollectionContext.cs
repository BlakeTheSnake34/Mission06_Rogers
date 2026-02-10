using Microsoft.EntityFrameworkCore;
using Mission06_Rogers.Models;

namespace Mission06_Rogers.Data;

public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}