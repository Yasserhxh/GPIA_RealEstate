using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the <see cref="Agent"/> entity.
/// </summary>
public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Agent"/> entity.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        /*builder.ToTable("Agents");

        // Defines the primary key for Agent.
        builder.HasKey(a => a.Id);

        // Configures the About property with a maximum length of 500 characters.
        builder.Property(a => a.About)
            .HasMaxLength(500);

        // Configures the Rating property with a default value of 0.
        builder.Property(a => a.Rating)
            .HasDefaultValue(0);

        // Configures the relationship between Agent and Assignments.
        builder.HasMany(a => a.Assignments)
            .WithOne(a => a.Agent)
            .HasForeignKey(a => a.AgentId);

        // Configures the relationship between Agent and Appointments.
        builder.HasMany(a => a.Appointments)
            .WithOne(ap => ap.Agent)
            .HasForeignKey(ap => ap.AgentId);*/
    }
}