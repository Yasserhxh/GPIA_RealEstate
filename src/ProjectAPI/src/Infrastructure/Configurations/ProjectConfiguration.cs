using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // Configure Project entity

        builder.ToTable("Projects");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Location).HasMaxLength(250);
        builder.Property(p => p.Address).HasMaxLength(250);
        builder.Property(p => p.Images).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
      
    }
}
