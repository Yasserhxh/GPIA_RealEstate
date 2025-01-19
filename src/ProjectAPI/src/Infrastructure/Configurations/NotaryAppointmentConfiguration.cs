﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectAPI.Domain.Appointments.Entities;

namespace ProjectAPI.Infrastructure.Configurations;

public class NotaryAppointmentConfiguration : IEntityTypeConfiguration<NotaryAppointment>
{
    public void Configure(EntityTypeBuilder<NotaryAppointment> builder)
    {
        builder.ToTable("NotaryAppointments");

        builder.HasKey(na => na.Id);

        builder.Property(na => na.BuyerId).HasMaxLength(450);
        builder.Property(na => na.NotaireId).HasMaxLength(450);
        builder.Property(na => na.AgentId).HasMaxLength(450);
        builder.Property(na => na.ConnectedUserId).HasMaxLength(450);
        builder.Property(na => na.Status).IsRequired().HasMaxLength(50);
        builder.Property(na => na.PropertyPrice).HasColumnType("decimal(18,2)");
        builder.Property(na => na.TaxFees).HasColumnType("decimal(18,2)");
        builder.Property(na => na.TahfidFees).HasColumnType("decimal(18,2)");

        builder.HasOne(na => na.Reservation)
            .WithMany()
            .HasForeignKey(na => na.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
