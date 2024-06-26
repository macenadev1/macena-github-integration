using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Models.GetRepositoryDetails
{
    /// <summary>
    /// Represents a response to Get Repository Details
    /// </summary>
    public class GetRepositoryDetailsResponse : OperationResponse
    {
        /// <summary>
        /// Represents a GitHub repository item.
        /// </summary>
        public GitHubRepositoryItem GitHubRepositoryItem { get; set; }
    }
}