namespace Macena.GitHub.Models.GetAllRepositories
{
    /// <summary>
    /// Represents filters for querying GitHub repositories.
    /// </summary>
    public class GetAllRepositoriesRequest : OperationRequest
    {
        /// <summary>
        /// Gets or sets the programming language filter.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the page number for pagination.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the page size for pagination.
        /// </summary>
        public int? PageSize { get; set; }
    }
}