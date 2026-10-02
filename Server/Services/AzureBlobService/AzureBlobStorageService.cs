using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using Server.Settings;

namespace Server.Services.AzureBlobService;

/// <inheritdoc cref="IAzureBlobStorageService"/>
public class AzureBlobStorageService(IOptionsMonitor<ApplicationSettings> applicationSettings) : IAzureBlobStorageService
{
    /// <summary>
    /// The IOptionsMonitor instance used to access the current configuration settings for Azure Blob Storage, allowing the service to dynamically retrieve configuration values at runtime.
    /// </summary>
    private readonly IOptionsMonitor<ApplicationSettings> _applicationSettings = applicationSettings;

    /// <summary>
    /// Retrieves the name of the container in Azure Blob Storage from the current configuration settings. This property is used to specify which container to access when retrieving blobs such as profile pictures and resumes.
    /// </summary>
    private string ContainerName => GetAzureBlobStorageSettings().ContainerName;

    /// <summary>
    /// Retrieves the connection string for Azure Blob Storage from the current configuration settings. This property is used to establish a connection to the Azure Blob Storage account when retrieving blobs.
    /// </summary>
    private string ConnectionString => GetAzureBlobStorageSettings().ConnectionString;

    /// <inheritdoc cref="IAzureBlobStorageService.GetBlobClient(string)"/>
    public BlobClient GetBlobClient(string blobName)
    {
        BlobServiceClient blobServiceClient;

        try
        {
            blobServiceClient = new BlobServiceClient(ConnectionString);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error creating BlobServiceClient: {ex.Message}", ex);
        }

        try
        {
            return blobServiceClient
                .GetBlobContainerClient(ContainerName)
                .GetBlobClient(blobName);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error retrieving blob '{blobName}' from container '{ContainerName}': {ex.Message}", ex);
        }
    }

    private AzureBlobStorageSettings GetAzureBlobStorageSettings()
    {
        if (_applicationSettings == null || 
            _applicationSettings.CurrentValue == null || 
            _applicationSettings.CurrentValue.AzureBlobStorage == null)
        {
            throw new InvalidOperationException($"{nameof(AzureBlobStorageService)} : Application settings are not available.");
        }

        return _applicationSettings.CurrentValue.AzureBlobStorage;
    }
}
