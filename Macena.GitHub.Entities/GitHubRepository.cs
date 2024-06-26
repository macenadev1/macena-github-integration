namespace Macena.GitHub.Entities
{
    /// <summary>
    /// Represents a GitHub repository item.
    /// </summary>
    public class GitHubRepository
    {
        /// <summary>
        /// Gets or sets the ID of the repository.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the repository.
        /// </summary>
        public int IdGitHub { get; set; }

        /// <summary>
        /// Gets or sets the name of the repository.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the full name of the repository.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the URL to the repository's HTML page.
        /// </summary>
        public string? HtmlUrl { get; set; }

        /// <summary>
        /// Gets or sets the description of the repository.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the repository is a fork.
        /// </summary>
        public bool Fork { get; set; }

        /// <summary>
        /// Gets or sets the URL of the repository.
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the repository was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the repository was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the repository was last pushed to.
        /// </summary>
        public DateTime PushedAt { get; set; }

        /// <summary>
        /// Gets or sets the homepage URL of the repository.
        /// </summary>
        public string? Homepage { get; set; }

        /// <summary>
        /// Gets or sets the size of the repository.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the number of stargazers of the repository.
        /// </summary>
        public int StargazersCount { get; set; }

        /// <summary>
        /// Gets or sets the number of watchers of the repository.
        /// </summary>
        public int WatchersCount { get; set; }

        /// <summary>
        /// Gets or sets the primary programming language used in the repository.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the number of forks of the repository.
        /// </summary>
        public int ForksCount { get; set; }

        /// <summary>
        /// Gets or sets the number of open issues in the repository.
        /// </summary>
        public int OpenIssuesCount { get; set; }

        /// <summary>
        /// Gets or sets the default branch of the repository.
        /// </summary>
        public string? DefaultBranch { get; set; }

        /// <summary>
        /// Gets or sets the score of the repository in the search results.
        /// </summary>
        public double Score { get; set; }
    }
}