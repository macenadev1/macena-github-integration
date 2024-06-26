using Macena.GitHub.Entities;
using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Core.Mapping
{
    /// <summary>
    /// Provides mapping extensions for GitHub repository entities.
    /// </summary>
    public static class GetAllRepositoriesMapper
    {
        /// <summary>
        /// Maps a <see cref="GitHubRepository"/> to a <see cref="GitHubRepositoryItem"/>.
        /// </summary>
        /// <param name="self">The <see cref="GitHubRepository"/> to map from.</param>
        /// <returns>A <see cref="GitHubRepositoryItem"/> if <paramref name="self"/> is not null; otherwise, null.</returns>
        public static GitHubRepositoryItem? Map(this GitHubRepository self) =>
            self == null ? null :
            new GitHubRepositoryItem
            {
                Id = self.IdGitHub,
                Name = self.Name,
                FullName = self.FullName,
                HtmlUrl = self.HtmlUrl,
                Description = self.Description,
                Fork = self.Fork,
                Url = self.Url,
                CreatedAt = self.CreatedAt,
                UpdatedAt = self.UpdatedAt,
                PushedAt = self.PushedAt,
                Homepage = self.Homepage,
                Size = self.Size,
                StargazersCount = self.StargazersCount,
                WatchersCount = self.WatchersCount,
                Language = self.Language,
                ForksCount = self.ForksCount,
                OpenIssuesCount = self.OpenIssuesCount,
                DefaultBranch = self.DefaultBranch,
                Score = self.Score
            };
    }
}