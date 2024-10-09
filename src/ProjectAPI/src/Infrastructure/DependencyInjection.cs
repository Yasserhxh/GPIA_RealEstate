using Microsoft.EntityFrameworkCore;
using ProjectAPI.Domain.FeedBacks.Interfaces;
using ProjectAPI.Domain.Projects.Interfaces;
using ProjectAPI.Infrastructure.Context;
using ProjectAPI.Infrastructure.Repositories;
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

    private static void ConfigureDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlPrimary")), ServiceLifetime.Scoped);
    }
    private static void ConfigureCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IFeedbackRepository, IFeedbackRepository>();

    }

    #endregion
}
