﻿using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.Appointments.Interfaces;
using ProjectAPI.Domain.Common.Interfaces;
using ProjectAPI.Domain.FeedBacks.Interfaces;
using ProjectAPI.Domain.Immeubles.Interfaces;
using ProjectAPI.Domain.Projects.Interfaces;
using ProjectAPI.Domain.Reservations.Interface;
using ProjectAPI.Domain.Users.Entities;
using ProjectAPI.Domain.Users.Interfaces;
using ProjectAPI.Infrastructure.Context;
using ProjectAPI.Infrastructure.Providers;
using ProjectAPI.Infrastructure.Settings;

namespace ProjectAPI.Infrastructure;
/// <summary>
/// Represents a static class for dependency injection configuration.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to register infrastructure services required by the application.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance representing the application's configuration.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> instance with added services.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register JWT settings
        services.ConfigureSettings(configuration);

        // Register DbContexts
        services.ConfigureDbContexts(configuration);

        // Add identity to get user informations
        services.ConfigureIdentity();

        // Register custom services
        services.ConfigureCustomServices();
        return services;
    }
    #region Helpers

    private static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        var otpSettings = new OtpSettings();

        configuration.Bind("JwtSettings", jwtSettings);
        configuration.Bind("OtpSettings", otpSettings);

        services
            .AddSingleton(jwtSettings)
            .AddSingleton(otpSettings);
    }
    private static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
    private static void ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlPrimary")), ServiceLifetime.Scoped);
    }
    private static void ConfigureCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IImmeubleRepository, ImmeubleRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IAgentRepository, AgentRepository>();
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<ILikedProjectRepository, LikedProjectRepository>();
        services.AddScoped<IImmeubleFeatureRepository, ImmeubleFeatureRepository>();
        services.AddScoped<IProjectFeatureRepository, ProjectFeatureRepository>();
        services.AddScoped<ILeadRepository, LeadRepository>();
        services.AddScoped<IPerformanceIndicatorRepository, PerformanceIndicatorRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IImmeubleTrackingRepository, ImmeubleTrackingRepository>();
        services.AddScoped<INotaryAppointmentRepository, NotaryAppointmentRepository>();




        services.AddScoped<IBlobStorageService, BlobStorageService>(); // Register BlobStorageService as Scoped

        // Register BlobContainerClient as Singleton
        services.AddSingleton(provider =>
        {
            // Retrieve configuration settings
            var configuration = provider.GetRequiredService<IConfiguration>();
            var blobServiceUri = configuration["BlobStorage:ServiceUri"];
            var accountName = configuration["BlobStorage:AccountName"];
            var accountKey = configuration["BlobStorage:AccountKey"];

            // Validate configuration
            if (string.IsNullOrEmpty(blobServiceUri) || string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(accountKey))
                throw new InvalidOperationException("Blob storage configuration is missing or incomplete.");

            // Create and return BlobContainerClient
            var credential = new Azure.Storage.StorageSharedKeyCredential(accountName, accountKey);
            return new BlobContainerClient(new Uri(blobServiceUri), credential);
        });

    }

    #endregion
}
