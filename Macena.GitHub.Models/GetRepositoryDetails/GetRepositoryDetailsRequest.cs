namespace Macena.GitHub.Models.GetRepositoryDetails
{
    /// <summary>
    /// Represents filters for querying GitHub repositories.
    /// </summary>
    public class GetRepositoryDetailsRequest : OperationRequest
    {
        /// <summary>
        /// Id GitHub Repository
        /// </summary>
        public int Id { get; set; }
    }
}