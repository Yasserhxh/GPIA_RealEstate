using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Projects.Entities;

namespace ProjectAPI.Infrastructure.Configurations
{
    /// <summary>
    /// Configuration class for the <see cref="Unit"/> entity.
    /// </summary>
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="Unit"/> entity.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");

            // Defines the primary key for Unit.
            builder.HasKey(unit => unit.Id);

            // Configures the Floor property to be required.
            builder.Property(unit => unit.Floor)
                .IsRequired()
                .HasMaxLength(50);

            // Configures the UnitNumber property to be required.
            builder.Property(unit => unit.UnitNumber)
                .IsRequired()
                .HasMaxLength(50);

            // Configures the NumberOfBedrooms property to be required.
            builder.Property(unit => unit.NumberOfBedrooms)
                .IsRequired();

            // Configures the NumberOfBathrooms property to be required.
            builder.Property(unit => unit.NumberOfBathrooms)
                .IsRequired();

            // Configures the ApartmentSurface property to be required.
            builder.Property(unit => unit.ApartmentSurface)
                .IsRequired();

            // Configures the BalconySurface property.
            builder.Property(unit => unit.BalconySurface);

            // Configures the TerraceSurface property.
            builder.Property(unit => unit.TerraceSurface);

            // Configures the GardenSurface property.
            builder.Property(unit => unit.GardenSurface);

            // Configures the View property.
            builder.Property(unit => unit.View)
                .HasMaxLength(150);

            // Configures the Orientation property.
            builder.Property(unit => unit.Orientation)
                .HasMaxLength(100);

            // Configures the TotalSurface property to be required.
            builder.Property(unit => unit.TotalSurface)
                .IsRequired();

            // Configures the Price property to be required.
            builder.Property(unit => unit.Price)
                .IsRequired();

            // Configures the relationship between Unit and Project.
            builder.HasOne(unit => unit.Project)
                .WithMany(project => project.Units)
                .HasForeignKey(unit => unit.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}