namespace Genocs.Common.Settings;

/// <summary>
/// The application settings
/// </summary>
public class AppOptions
{
    /// <summary>
    /// Default section name
    /// </summary>
    public static string Position = "App";

    /// <summary>
    /// Application name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Service name
    /// </summary>
    public string? Service { get; set; }

    /// <summary>
    /// The instance of the service
    /// </summary>
    public string? Instance { get; set; }

    /// <summary>
    /// The application version
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// It defines whether the banner is shown into the console at startup time or not
    /// </summary>
    public bool DisplayBanner { get; set; }

    /// <summary>
    /// It defines whether the application version is shown into the console at startup time or not
    /// </summary>
    public bool DisplayVersion { get; set; }
}