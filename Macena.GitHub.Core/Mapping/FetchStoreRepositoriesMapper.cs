using Macena.GitHub.Entities;
using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Core.Mapping
{
    /// <summary>
    /// Provides extension methods for mapping GitHub repository items.
    /// </summary>
    public static class FetchStoreRepositoriesMapper
    {
        /// <summary>
        /// Maps a <see cref="GitHubRepositoryItem"/> to a <see cref="GitHubRepository"/>.
        /// </summary>
        /// <param name="self">The <see cref="GitHubRepositoryItem"/> to map from.</param>
        /// <returns>A <see cref="GitHubRepository"/> if <paramref name="self"/> is not null; otherwise, null.</returns>
        public static GitHubRepository? Map(this GitHubRepositoryItem self) =>
            self == null ? null :
            new GitHubRepository
            {
                IdGitHub = self.Id,
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
