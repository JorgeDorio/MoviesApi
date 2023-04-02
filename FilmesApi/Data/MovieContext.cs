using MoviesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
