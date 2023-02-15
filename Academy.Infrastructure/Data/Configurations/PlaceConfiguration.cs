using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class PlaceConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("DATE('now')");
    }
}