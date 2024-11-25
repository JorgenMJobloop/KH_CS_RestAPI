using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Movies> Movies { get; set; }
    public DbSet<TVShows> TVShows { get; set; }

    public DbSet<IMDBTopTenModel> IMDBTopTen { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}