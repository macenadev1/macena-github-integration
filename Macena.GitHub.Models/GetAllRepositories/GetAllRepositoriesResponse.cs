using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Models.GetAllRepositories
{
    /// <summary>
    /// Represents a response to Get All Repositories
    /// </summary>
    public class GetAllRepositoriesResponse : OperationResponse
    {
        /// <summary>
        /// Represents a GitHub List repository item.
        /// </summary>
        public List<GitHubRepositoryItem> GitHubRepositoryItem { get; set; }
    }
}