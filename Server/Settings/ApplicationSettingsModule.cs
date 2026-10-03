namespace Server.Settings;

/// <summary>
/// Provides extension methods for configuring application settings in the service collection.
/// </summary>
public static class ApplicationSettingsModule
{
    /// <summary>
    /// Configures the application settings by binding the configuration sections to their respective classes.
    /// </summary>
    /// <param name="services">The service collection to which the configuration settings will be added.</param>
    /// <param name="configuration">The configuration settings instance that contains the values that are being bound.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection ConfigureApplicationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection applicationSettingsSection = configuration.GetSection(nameof(ApplicationSettings));

        return services
            .Configure<ApplicationSettings>(applicationSettingsSection)
            .Configure<CorsSettings>(applicationSettingsSection.GetSection(CorsSettings.SectionName))
            .Configure<AzureBlobStorageSettings>(applicationSettingsSection.GetSection(AzureBlobStorageSettings.SectionName));
    }
}
