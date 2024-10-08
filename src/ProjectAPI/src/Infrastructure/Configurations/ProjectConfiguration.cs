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
            builder.HasKey(ast => ast.Id);

            // Configures the Name property to be required.
            builder.Property(ast => ast.Name)
                .IsRequired()
                .HasMaxLength(150);

            // Configures the Location property to be required.
            builder.Property(ast => ast.Location)
                .IsRequired();

            // Configures the Images property to be required.
            builder.Property(ast => ast.Images)
                .IsRequired();

            // Configures the Type property to be required.
            builder.Property(ast => ast.Type)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
