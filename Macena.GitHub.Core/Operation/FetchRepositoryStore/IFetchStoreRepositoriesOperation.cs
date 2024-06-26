using Macena.GitHub.Models.FetchRepositoryStore;
using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Core.Operation.FetchRepositoryStore
{
    /// <summary>
    /// Interface for operations related to fetching and storing repositories.
    /// </summary>
    public interface IFetchStoreRepositoriesOperation : IBaseOperation<FetchStoreRepositoriesRequest, FetchStoreRepositoriesResponse>
    {
        /// <summary>
        /// Retrieves the top repositories asynchronously based on the specified language.
        /// </summary>
        /// <param name="language">The programming language to search for.</param>
        /// <returns>A list of GitHubRepositoryItem representing the top repositories.</returns>
        Task<List<GitHubRepositoryItem>> GetTopRepositoriesAsync(string language);
    }
}
