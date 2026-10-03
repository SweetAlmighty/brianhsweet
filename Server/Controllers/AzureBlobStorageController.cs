using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Services.AzureBlobService;
using Server.Settings;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Server.Controllers;

/// <summary>
/// The BlobStorageController is responsible for handling requests related to Azure Blob Storage, such as retrieving profile pictures and resumes. It uses the IBlobService to interact with Azure Blob Storage and retrieves configuration settings from ApplicationSettings.
/// </summary>
/// <param name="applicationSettings">The IOptionsMonitor<ApplicationSettings> instance used to access the current configuration settings for Azure Blob Storage, including connection strings, container names, and blob names. This allows the controller to dynamically retrieve configuration values at runtime.</param>
/// <param name="azureBlobStorageService">The IBlobService instance used to interact with Azure Blob Storage, allowing the controller to retrieve blobs such as profile pictures and resumes.</param>
[ApiController]
[Route("api/[controller]")]
public class AzureBlobStorageController(IOptionsMonitor<ApplicationSettings> applicationSettings, IAzureBlobStorageService azureBlobStorageService) : ControllerBase
{
    /// <summary>
    /// The BlobStorageController is responsible for handling requests related to Azure Blob Storage, such as retrieving profile pictures and resumes. It uses the IBlobService to interact with Azure Blob Storage and retrieves configuration settings from ApplicationSettings.
    /// </summary>
    private readonly IAzureBlobStorageService _azureBlobStorageService = azureBlobStorageService;

    /// <summary>
    /// The IOptionsMonitor<ApplicationSettings> instance used to access the current configuration settings for Azure Blob Storage, including connection strings, container names, and blob names. This allows the controller to dynamically retrieve configuration values at runtime.
    /// </summary>
    private readonly IOptionsMonitor<ApplicationSettings> _applicationSettings = applicationSettings;

    /// <summary>
    /// The name of the blob for the resume, including the file extension, retrieved from the current configuration settings. This property is used to specify which blob to access when retrieving the resume from Azure Blob Storage.
    /// </summary>
    private string ResumeBlobName => GetAzureBlobStorageSettings().ResumeBlobName;

    /// <summary>
    /// The name of the blob for the profile picture, including the file extension, retrieved from the current configuration settings. This property is used to specify which blob to access when retrieving the profile picture from Azure Blob Storage.
    /// </summary>
    private string ProfilePictureBlobName => GetAzureBlobStorageSettings().ProfilePictureBlobName;

    /// <summary>
    /// Endpoint to retrieve the profile picture blob from Azure Blob Storage and returns it as a file response.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the profile picture file.</returns>
    [HttpGet(nameof(GetProfilePicture))]
    public async Task<IActionResult> GetProfilePicture()
    {
        try
        {
            if (string.IsNullOrEmpty(ProfilePictureBlobName))
            {
                throw new InvalidOperationException("Profile picture blob name is not configured in Azure Blob Storage settings.");
            }

            return await GetBlob(ProfilePictureBlobName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving profile picture blob name from configuration: {ex.Message}");
        }
    }

    /// <summary>
    /// Endpoint to retrieve the resume blob from Azure Blob Storage and returns it as a file response.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the resume file.</returns>
    [HttpGet(nameof(GetResume))]
    public async Task<IActionResult> GetResume()
    {
        try
        {
            if (string.IsNullOrEmpty(ResumeBlobName))
            {
                throw new InvalidOperationException("Resume blob name is not configured in Azure Blob Storage settings.");
            }

            return await GetBlob(ResumeBlobName);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving resume blob name from configuration: {ex.Message}");
        }
    }

    /// <summary>
    /// Retrieves a blob from Azure Blob Storage based on the provided blob name and returns it as a file response.
    /// This method is used internally by the GetProfilePicture and GetResume endpoints to fetch the respective blobs.
    /// </summary>
    /// <param name="blobName">The name of the blob to retrieve from Azure Blob Storage.</param>
    /// <returns>An <see cref="IActionResult"/> containing the requested blob file.</returns>
    private async Task<IActionResult> GetBlob(string blobName)
    {
        BlobClient blobServiceClient = _azureBlobStorageService.GetBlobClient(blobName)
            ?? throw new InvalidOperationException("Application settings are not available.");

        Azure.Response<BlobDownloadStreamingResult> response = await blobServiceClient.DownloadStreamingAsync();

        if (response == null || response.Value.Content == null)
        {
            throw new InvalidOperationException($"Blob '{blobName}' not found in container.");
        }

        return File(
            response.Value.Content,
            response.Value.Details.ContentType ?? "application/octet-stream",
            blobName);
    }

    private AzureBlobStorageSettings GetAzureBlobStorageSettings()
    {
        if (_applicationSettings == null ||
            _applicationSettings.CurrentValue == null ||
            _applicationSettings.CurrentValue.AzureBlobStorage == null)
        {
            throw new InvalidOperationException($"{nameof(AzureBlobStorageController)} : Application settings are not available.");
        }

        return _applicationSettings.CurrentValue.AzureBlobStorage;
    }
}
