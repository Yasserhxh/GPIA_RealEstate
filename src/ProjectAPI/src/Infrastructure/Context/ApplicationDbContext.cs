using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Projects.Entities;
using ProjectAPI.Domain.Users.Entities;
using ProjectAPI.Infrastructure.Configurations;
using RealEstate.Infrastructure.Configurations;

namespace ProjectAPI.Infrastructure.Context;

/// <summary>
/// Represents the application database context, extending IdentityDbContext for Project management.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<ProjectAssignment> Assignments { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentReview> AppointmentReviews { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProjectConfiguration());
        builder.ApplyConfiguration(new UnitConfiguration());
        builder.ApplyConfiguration(new FeedbackConfiguration()); 
        builder.ApplyConfiguration(new AppointmentConfiguration());
        builder.ApplyConfiguration(new AppointmentReviewConfiguration());
        builder.ApplyConfiguration(new IncidentConfiguration());
        builder.ApplyConfiguration(new NotaryAppointmentConfiguration());
        builder.ApplyConfiguration(new PropertyDeliveryConfiguration());
    }
    /// <summary>
    /// Constructor for ApplicationDbContext.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}