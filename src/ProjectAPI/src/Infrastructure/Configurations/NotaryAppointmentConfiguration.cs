using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Domain.Appointments.Entities;

namespace ProjectAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration class for the <see cref="NotaryAppointment"/> entity.
    /// </summary>
    public class NotaryAppointmentConfiguration : IEntityTypeConfiguration<NotaryAppointment>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="NotaryAppointment"/> entity.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<NotaryAppointment> builder)
        {
            builder.ToTable("NotaryAppointments");

            // Configures the primary key for the NotaryAppointment entity.
            builder.HasKey(na => na.Id);

            // Configures the UserId property to be required.
            builder.Property(na => na.UserId).IsRequired();

            // Configures the SaleId property to be required.
            builder.Property(na => na.SaleId).IsRequired();

            // Configures the AppointmentDate property to be required.
            builder.Property(na => na.AppointmentDate).IsRequired();

            // Configures the Status property with a maximum length of 50 characters and makes it required.
            builder.Property(na => na.Status).HasMaxLength(50).IsRequired();
        }
    }
}