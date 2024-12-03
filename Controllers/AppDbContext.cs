using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    /// <summary>
    /// Movies is a part of production code!
    /// </summary>
    public DbSet<Movies> Movies { get; set; }
    /// <summary>
    /// TVShows is a part of production code!
    /// </summary>
    public DbSet<TVShows> TVShows { get; set; }

    /// <summary>
    /// Mock class used for testing purposes, not a part of production
    /// </summary>
    public DbSet<IMDBTopTenModel> IMDBTopTen { get; set; }
    /// <summary>
    /// Mock class used for testing purposes, not a part of production
    /// </summary>
    public DbSet<ImageSupport> TestImageSupport { get; set; }
    /// <summary>
    /// Mock user table
    /// </summary>
    public DbSet<MockUsers> TestModel { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}