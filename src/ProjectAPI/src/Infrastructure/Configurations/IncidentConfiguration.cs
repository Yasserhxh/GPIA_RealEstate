using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.FeedBacks.Entities;

namespace ProjectAPI.Infrastructure.Configurations;
/// <summary>
/// Configuration class for the <see cref="Incident"/> entity.
/// </summary>
public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
{
    public void Configure(EntityTypeBuilder<Incident> builder)
    {
        builder.ToTable("Incidents");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.UserId).IsRequired();
        builder.Property(i => i.UnitId).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(1000).IsRequired();
        builder.Property(i => i.Status).HasMaxLength(50).IsRequired();
        builder.Property(i => i.ReportedAt).IsRequired();
    }
}
