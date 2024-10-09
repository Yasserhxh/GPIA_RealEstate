using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Infrastructure.Configurations;

namespace ProjectAPI.Infrastructure.Context;

/// <summary>
/// Represents the application database context, extending IdentityDbContext for Project management.
/// </summary>
public class ApplicationDbContext :  DbContext
{
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProjectConfiguration());
        builder.ApplyConfiguration(new FeedbackConfiguration());
    }
    /// <summary>
    /// Constructor for ApplicationDbContext.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}