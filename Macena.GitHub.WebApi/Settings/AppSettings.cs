using Macena.GitHub.Core.Settings;

namespace Macena.GitHub.WebApi.Settings
{
    /// <summary>
    /// Provides application settings by reading from configuration sources.
    /// </summary>
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class.
        /// </summary>
        /// <param name="configuration">The configuration instance to retrieve settings from.</param>
        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the base URL for GitHub language repositories from the configuration.
        /// </summary>
        public string BaseUrlLanguageGitHub => _configuration["BaseUrlLanguageGitHub"];

        /// <summary>
        /// Access Token GitHub
        /// </summary>
        public string AccessTokenGitHub => _configuration["AccessTokenGitHub"];

        /// <summary>
        /// Gets the default languages to search from the configuration.
        /// </summary>
        public List<string> DefaultLanguageSearch
        {
            get
            {
                var languages = new List<string>();
                _configuration.GetSection("DefaultLanguageSearch").Bind(languages);
                return languages;
            }
        }
    }
}
