using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Appointments.Entities;

namespace ProjectAPI.Infrastructure.Configurations;

/// <summary>
/// Configuration class for the <see cref="Appointment"/> entity.
/// </summary>
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    /// <summary>
    /// Configures the properties and relationships of the <see cref="Appointment"/> entity.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        // Defines the primary key for Appointment.
        builder.HasKey(ap => ap.Id);

        // Configures the Name property with a maximum length of 150 characters.
        builder.Property(ap => ap.Name)
            .HasMaxLength(150);

        // Configures the Email property with a maximum length of 150 characters.
        builder.Property(ap => ap.Email)
            .HasMaxLength(150);

        // Configures the PhoneNumber property with a maximum length of 20 characters.
        builder.Property(ap => ap.PhoneNumber)
            .HasMaxLength(20);

        // Configures the AppointmentDate property to be required.
        builder.Property(ap => ap.AppointmentDate)
            .IsRequired();

        // Configures the relationship between Appointment and Project.
        builder.HasOne(ap => ap.Project)
            .WithMany(p => p.Appointments)
            .HasForeignKey(ap => ap.ProjectId);

        // Configures the relationship between Appointment and Agent.
        builder.HasOne(ap => ap.Agent)
            .WithMany(a => a.Appointments)
            .HasForeignKey(ap => ap.AgentId);
    }
}