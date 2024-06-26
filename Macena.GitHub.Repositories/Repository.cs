using System.Data.SqlClient;
using Dapper;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace Macena.GitHub.Repositories
{
    /// <summary>
    /// Repository class that handles data operations for GitHub repositories.
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
            string query = @"INSERT INTO GitHubRepositories (IdGitHub, Name, FullName, HtmlUrl, Description, Fork, Url, CreatedAt, UpdatedAt, PushedAt, Homepage, Size, StargazersCount, WatchersCount, Language, ForksCount, OpenIssuesCount, DefaultBranch, Score)
                     VALUES (@IdGitHub, @Name, @FullName, @HtmlUrl, @Description, @Fork, @Url, @CreatedAt, @UpdatedAt, @PushedAt, @Homepage, @Size, @StargazersCount, @WatchersCount, @Language, @ForksCount, @OpenIssuesCount, @DefaultBranch, @Score)";

            using (var sqlConnection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                await sqlConnection.OpenAsync();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    await sqlConnection.ExecuteAsync(query, gitHub, transaction);

                    transaction.Commit();
                }
            }

            return gitHub.IdGitHub;
        }

        /// <summary>
        /// Verify if Exists a document
        /// </summary>
        /// <param name="id">The ID of the GitHub repository.</param>
        /// <returns>True if Exists</returns>
        public async Task<bool> ExistsAsync(int id)
        {
            using (var sqlConnection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                await sqlConnection.OpenAsync();

                var query = "SELECT COUNT(1) FROM GitHubRepositories WHERE IdGitHub = @Id";
                var exists = await sqlConnection.ExecuteScalarAsync<bool>(query, new { Id = id });

                return exists;
            }
        }

        /// <summary>
        /// Retrieves all GitHub repositories from the database.
        /// </summary>
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
            return await _context.GitHubRepositories.SingleOrDefaultAsync(d => d.IdGitHub == id);
        }
    }
}
