using Newtonsoft.Json;

namespace Macena.GitHub.Models.GitHubSearch
{
    /// <summary>
    /// Represents the response from a GitHub search API request.
    /// </summary>
    public class GitHubSearchResponse
    {
        /// <summary>
        /// Gets or sets the total count of repositories found.
        /// </summary>
        [JsonProperty("Total_Count")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the results are incomplete.
        /// </summary>
        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        /// <summary>
        /// Gets or sets the list of repository items found in the search.
        /// </summary>
        [JsonProperty("items")]
        public List<GitHubRepositoryItem>? Items { get; set; }

        /// <summary>
        /// Represents a GitHub repository item.
        /// </summary>
        public class GitHubRepositoryItem
        {
            /// <summary>
            /// Gets or sets the ID of the repository.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the name of the repository.
            /// </summary>
            [JsonProperty("name")]
            public string? Name { get; set; }

            /// <summary>
            /// Gets or sets the full name of the repository.
            /// </summary>
            [JsonProperty("full_name")]
            public string? FullName { get; set; }

            /// <summary>
            /// Gets or sets the owner of the repository.
            /// </summary>
            [JsonProperty("owner")]
            public GitHubOwner? Owner { get; set; }

            /// <summary>
            /// Gets or sets the URL to the repository's HTML page.
            /// </summary>
            [JsonProperty("html_url")]
            public string? HtmlUrl { get; set; }

            /// <summary>
            /// Gets or sets the description of the repository.
            /// </summary>
            [JsonProperty("description")]
            public string? Description { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the repository is a fork.
            /// </summary>
            [JsonProperty("fork")]
            public bool Fork { get; set; }

            /// <summary>
            /// Gets or sets the URL of the repository.
            /// </summary>
            [JsonProperty("url")]
            public string? Url { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the repository was created.
            /// </summary>
            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the repository was last updated.
            /// </summary>
            [JsonProperty("updated_at")]
            public DateTime UpdatedAt { get; set; }

            /// <summary>
            /// Gets or sets the date and time when the repository was last pushed to.
            /// </summary>
            [JsonProperty("pushed_at")]
            public DateTime PushedAt { get; set; }

            /// <summary>
            /// Gets or sets the homepage URL of the repository.
            /// </summary>
            [JsonProperty("homepage")]
            public string? Homepage { get; set; }

            /// <summary>
            /// Gets or sets the size of the repository.
            /// </summary>
            [JsonProperty("size")]
            public int Size { get; set; }

            /// <summary>
            /// Gets or sets the number of stargazers of the repository.
            /// </summary>
            [JsonProperty("stargazers_count")]
            public int StargazersCount { get; set; }

            /// <summary>
            /// Gets or sets the number of watchers of the repository.
            /// </summary>
            [JsonProperty("watchers_count")]
            public int WatchersCount { get; set; }

            /// <summary>
            /// Gets or sets the primary programming language used in the repository.
            /// </summary>
            [JsonProperty("language")]
            public string? Language { get; set; }

            /// <summary>
            /// Gets or sets the number of forks of the repository.
            /// </summary>
            [JsonProperty("forks_count")]
            public int ForksCount { get; set; }

            /// <summary>
            /// Gets or sets the number of open issues in the repository.
            /// </summary>
            [JsonProperty("open_issues_count")]
            public int OpenIssuesCount { get; set; }

            /// <summary>
            /// Gets or sets the default branch of the repository.
            /// </summary>
            [JsonProperty("default_branch")]
            public string? DefaultBranch { get; set; }

            /// <summary>
            /// Gets or sets the score of the repository in the search results.
            /// </summary>
            [JsonProperty("score")]
            public double Score { get; set; }
        }

        /// <summary>
        /// Represents the owner of a GitHub repository.
        /// </summary>
        public class GitHubOwner
        {
            /// <summary>
            /// Gets or sets the login name of the owner.
            /// </summary>
            [JsonProperty("login")]
            public string? Login { get; set; }

            /// <summary>
            /// Gets or sets the ID of the owner.
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the URL of the owner's avatar image.
            /// </summary>
            [JsonProperty("avatar_url")]
            public string? AvatarUrl { get; set; }

            /// <summary>
            /// Gets or sets the URL of the owner's profile.
            /// </summary>
            [JsonProperty("url")]
            public string? Url { get; set; }

            /// <summary>
            /// Gets or sets the type of the owner (e.g., User, Organization).
            /// </summary>
            [JsonProperty("type")]
            public string? Type { get; set; }
        }
    }
}
