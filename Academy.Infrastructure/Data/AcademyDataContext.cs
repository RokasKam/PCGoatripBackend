using Academy.Domain.Entities;
using Academy.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Data;

public class AcademyDataContext : DbContext
{

public DbSet<Place> Places { get; set; }

public DbSet<User> Users { get; set; }

public DbSet<UserPlace> UserPlaces { get; set; }

    public AcademyDataContext(DbContextOptions<AcademyDataContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaceConfiguration).Assembly);
    }
}