namespace Server.Settings;

/// <summary>
/// Represents the configuration settings for Azure Blob Storage.
/// </summary>
public class AzureBlobStorageSettings
{
    /// <summary>
    /// The name of the configuration section in the application settings.
    /// </summary>
    public static string SectionName => "AzureBlobStorage";

    /// <summary>
    /// The connection string for the Azure Blob Storage account.
    /// </summary>
    public required string ConnectionString { get; init; }

    /// <summary>
    /// The name of the container in Azure Blob Storage.
    /// </summary>
    public required string ContainerName { get; init; }

    /// <summary>
    /// The name of the blob for the profile picture, including the file extension.
    /// </summary>
    public required string ProfilePictureBlobName { get; init; }

    /// <summary>
    /// The name of the blob for the resume, including the file extension.
    /// </summary>
    public required string ResumeBlobName { get; init; }
}
