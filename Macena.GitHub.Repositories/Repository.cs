using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace Macena.GitHub.Repositories
{
    /// <summary>
    /// Repository class that handles data operations for GitHub repositories using Entity Framework Core.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly RepositoryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Repository(RepositoryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new GitHub repository to the database.
        /// </summary>
        /// <param name="gitHub">The GitHub repository entity.</param>
        /// <returns>The ID of the added GitHub repository.</returns>
        public async Task<int> AddAsync(GitHubRepository gitHub)
        {
            _context.GitHubRepositories.Add(gitHub);
            await _context.SaveChangesAsync();
            return gitHub.IdGitHub;
        }

        /// <summary>
        /// Verify if a GitHub repository exists by its ID.
        /// </summary>
        /// <param name="id">The ID of the GitHub repository.</param>
        /// <returns>True if the repository exists.</returns>
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.GitHubRepositories.AnyAsync(r => r.IdGitHub == id);
        }

        /// <summary>
        /// Retrieves all GitHub repositories from the database optionally filtered by language and paginated.
        /// </summary>
        /// <param name="language">The programming language to filter by.</param>
        /// <param name="page">The page number for pagination (1-based).</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A list of GitHub repositories.</returns>
        public async Task<List<GitHubRepository>> GetAllAsync(string? language = null, int? page = null, int? pageSize = null)
        {
            var query = _context.GitHubRepositories.AsQueryable();

            if (!string.IsNullOrEmpty(language))
            {
                query = query.Where(r => r.Language == language);
            }

            if (page.HasValue && pageSize.HasValue)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Retrieves a GitHub repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the GitHub repository.</param>
        /// <returns>The GitHub repository entity.</returns>
        public async Task<GitHubRepository> GetByIdAsync(int id)
        {
            return await _context.GitHubRepositories.FirstOrDefaultAsync(r => r.IdGitHub == id);
        }
    }
}
