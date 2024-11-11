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
        public void Configure(EntityTypeBuilder<NotaryAppointment> builder)
        {
            builder.ToTable("NotaryAppointments");

            builder.HasKey(na => na.Id);
            builder.Property(na => na.UserId).IsRequired();
            builder.Property(na => na.SaleId).IsRequired();
            builder.Property(na => na.AppointmentDate).IsRequired();
            builder.Property(na => na.Status).HasMaxLength(50).IsRequired();
        }
    }
}
