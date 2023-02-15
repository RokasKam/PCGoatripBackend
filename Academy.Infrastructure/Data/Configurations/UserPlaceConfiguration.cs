using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Data.Configurations;

public class UserPlaceConfiguration : IEntityTypeConfiguration<UserPlace>
{
    public void Configure(EntityTypeBuilder<UserPlace> builder)
    {
        builder.Property(x => x.CreationDate).HasDefaultValueSql("DATE('now')");
        builder.Property(x => x.ModificationDate).HasDefaultValueSql("DATE('now')");
        builder.HasOne(sc => sc.Place)
            .WithMany(s => s.UserPlaces)
            .HasForeignKey(sc => sc.PlaceId);
        builder.HasOne<User>(sc => sc.User)
            .WithMany(s => s.UserPlaces)
            .HasForeignKey(sc => sc.UserId);
    }
}