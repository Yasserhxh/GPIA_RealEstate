using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration class for the <see cref="Project"/> entity.
    /// </summary>
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="Project"/> entity.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            // Defines the primary key for Project.
            builder.HasKey(p => p.Id);

            // Configures the Name property to be required.
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Configures the Location property to be required.
            builder.Property(p => p.Location)
                .IsRequired();

            // Configures the Type property to be required.
            builder.Property(p => p.Type)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);

            // Configures the MinPrice property to be required.
            builder.Property(p => p.MinPrice)
                .IsRequired();

            // Configures the MaxPrice property to be required.
            builder.Property(p => p.MaxPrice)
                .IsRequired();

            // Configures the Status property to be required.
            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion<string>();

            // Configures the Images property to be required.
            builder.Property(p => p.Images)
                .IsRequired();

            // Configures the Description property.
            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            // Configures the Latitude property to be required.
            builder.Property(p => p.Latitude)
                .IsRequired();

            // Configures the Longitude property to be required.
            builder.Property(p => p.Longitude)
                .IsRequired();

            // Configures the MinSellableSurfaceRange property to be required.
            builder.Property(p => p.MinSellableSurfaceRange)
                .IsRequired();

            // Configures the MaxSellableSurfaceRange property to be required.
            builder.Property(p => p.MaxSellableSurfaceRange)
                .IsRequired();

            // Configures the relationships between Project and Assignments.
            builder.HasMany(p => p.Assignments)
                .WithOne(a => a.Project)
                .HasForeignKey(a => a.ProjectId);

            // Configures the relationships between Project and Appointments.
            builder.HasMany(p => p.Appointments)
                .WithOne(a => a.Project)
                .HasForeignKey(a => a.ProjectId);

            // Configures the relationships between Project and Units.
            builder.HasMany(p => p.Units)
                .WithOne(u => u.Project)
                .HasForeignKey(u => u.ProjectId);
        }
    }
}
