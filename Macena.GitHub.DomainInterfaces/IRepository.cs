using Macena.GitHub.Entities;

namespace Macena.GitHub.DomainInterfaces
{
    /// <summary>
    /// Interface for repository operations related to GitHub repositories.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Retrieves all GitHub repositories.
        /// </summary>
        /// <returns>A list of GitHub repositories.</returns>
        Task<List<GitHubRepository>> GetAllAsync(string? language = null, int? page = null, int? pageSize = null);

        /// <summary>
        /// Retrieves a GitHub repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the GitHub repository.</param>
        /// <returns>The GitHub repository entity.</returns>
        Task<GitHubRepository> GetByIdAsync(int id);

        /// <summary>
        /// Adds a new GitHub repository.
        /// </summary>
        /// <param name="github">The GitHub repository entity.</param>
        /// <returns>The ID of the added GitHub repository.</returns>
        Task<int> AddAsync(GitHubRepository github);

        /// <summary>
        /// Verify if Exists a document
        /// </summary>
        /// <param name="id">The ID of the GitHub repository.</param>
        /// <returns>True if Exists</returns>
        Task<bool> ExistsAsync(int id);
    }
}
