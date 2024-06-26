namespace Macena.GitHub.Models.FetchRepositoryStore
{
    /// <summary>
    /// Represents a request to fetch repositories from a store.
    /// </summary>
    public class FetchStoreRepositoriesRequest : OperationRequest
    {
        /// <summary>
        /// Gets or sets the list of languages to filter repositories.
        /// </summary>
        public List<string>? Languages { get; set; }
    }
}
