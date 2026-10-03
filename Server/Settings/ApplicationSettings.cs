namespace Server.Settings;

/// <summary>
/// Represents the configuration settings for the application.
/// </summary>
public class ApplicationSettings
{
    /// <summary>
    /// The CORS configuration settings, including allowed origins for cross-origin requests.
    /// </summary>
    public required CorsSettings Cors { get; init; }

    /// <summary>
    /// The Azure Blob Storage configuration.
    /// </summary>
    public required AzureBlobStorageSettings AzureBlobStorage { get; init; }
}
