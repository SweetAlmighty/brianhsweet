namespace Server.Settings;

/// <summary>
/// Represents the configuration settings for the application.
/// </summary>
public class ApplicationSettings
{
    /// <summary>
    /// The Azure Blob Storage configuration.
    /// </summary>
    public required AzureBlobStorageSettings AzureBlobStorage { get; init; }
}
