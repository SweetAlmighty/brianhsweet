using Azure.Storage.Blobs;

namespace Server.Services.AzureBlobService;

/// <summary>
/// Defines the contract for a service that interacts with Azure Blob Storage. It provides methods to retrieve BlobClient instances for accessing blobs in Azure Blob Storage based on account names and blob names.
/// </summary>
public interface IAzureBlobStorageService
{
    /// <summary>
    /// Retrieves a BlobClient instance for accessing a specific blob in Azure Blob Storage.
    /// </summary>
    /// <param name="blobName">The name of the blob to access.</param>
    /// <returns>A BlobClient instance for the specified blob.</returns>
    BlobClient GetBlobClient(string blobName);
}
