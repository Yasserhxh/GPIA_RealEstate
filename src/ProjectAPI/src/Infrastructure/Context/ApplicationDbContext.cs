using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Immeubles.Entities;
using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Users.Entities;
using ProjectAPI.Infrastructure.Configurations;
using System.Reflection.Emit;

namespace ProjectAPI.Infrastructure.Context;

/// <summary>
/// Represents the application database context, extending IdentityDbContext for Project management.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Immeuble> Immeubles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<ImmeubleAssignment> Assignments { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentReview> AppointmentReviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>(b =>
        {
            b.ToTable("AspNetUsers");
        });
        builder.ApplyConfiguration(new ProjectConfiguration());
        builder.ApplyConfiguration(new ImmeubleConfiguration());
        builder.ApplyConfiguration(new ImmeublePlanInterieurConfiguration());
        builder.ApplyConfiguration(new AppointmentConfiguration());
        builder.ApplyConfiguration(new PerformanceIndicatorConfiguration());
        builder.ApplyConfiguration(new UnitConfiguration());
        builder.ApplyConfiguration(new FeedbackConfiguration()); 
        builder.ApplyConfiguration(new AppointmentConfiguration());
        builder.ApplyConfiguration(new AppointmentReviewConfiguration());
        builder.ApplyConfiguration(new IncidentConfiguration());
        builder.ApplyConfiguration(new NotaryAppointmentConfiguration());
        builder.ApplyConfiguration(new PropertyDeliveryConfiguration());
        builder.ApplyConfiguration(new AssignmentConfiguration());
        builder.ApplyConfiguration(new LikedProjectsConfiguration());
    }
    /// <summary>
    /// Constructor for ApplicationDbContext.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}