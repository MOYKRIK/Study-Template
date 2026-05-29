using Lab3CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3CrudAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();

    public DbSet<Developer> Developers => Set<Developer>();

    public DbSet<Platform> Platforms => Set<Platform>();
}