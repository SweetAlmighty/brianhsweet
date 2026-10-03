namespace Server.Settings;

/// <summary>
/// Represents the configuration settings for Cross-Origin Resource Sharing (CORS), including allowed origins for cross-origin requests.
/// </summary>
public class CorsSettings
{
    /// <summary>
    /// The name of the configuration section in the application settings.
    /// </summary>
    public static string SectionName => "Cors";

    /// <summary>
    /// The list of allowed origins for cross-origin requests. This property is used to configure CORS policies in the application, specifying which domains are permitted to make requests to the server.
    /// </summary>
    public required string[] AllowedOrigins { get; init; }
}