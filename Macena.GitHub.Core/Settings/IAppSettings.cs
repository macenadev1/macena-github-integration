namespace Macena.GitHub.Core.Settings
{
    /// <summary>
    /// Represents the application settings.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Gets the base URL for GitHub language repositories.
        /// </summary>
        string BaseUrlLanguageGitHub { get; }

        /// <summary>
        /// Gets the default languages to search from the configuration.
        /// </summary>
        List<string> DefaultLanguageSearch { get; }

        /// <summary>
        /// Access Token GitHub
        /// </summary>
        string AccessTokenGitHub { get; }
    }
}
