using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Infrastructure.Configurations;

public class PerformanceIndicatorConfiguration : IEntityTypeConfiguration<PerformanceIndicator>
{
    public void Configure(EntityTypeBuilder<PerformanceIndicator> builder)
    {
        builder.ToTable("PerformanceIndicators");
        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.LeadsGenerated).IsRequired();
        builder.Property(pi => pi.AppointmentsScheduled).IsRequired();
        builder.Property(pi => pi.SuccessfulSales).IsRequired();
        builder.Property(pi => pi.ConversionRate).IsRequired();
        builder.Property(pi => pi.RecordedAt).IsRequired();
        builder.HasOne(pi => pi.Agent)
            .WithMany() // No navigation property on AspNetUsers for Performance Indicators
            .HasForeignKey(pi => pi.AgentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
