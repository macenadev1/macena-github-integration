using Macena.GitHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace Macena.GitHub.Repositories
{
    public class RepositoryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the DbSet of GitHub repositories.
        /// </summary>
        public DbSet<GitHubRepository> GitHubRepositories { get; set; }

        /// <summary>
        /// Configures the model relationships and entity mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GitHubRepository>().HasKey(d => d.Id);

            modelBuilder.Entity<GitHubRepository>().HasIndex(d => d.IdGitHub).IsUnique();

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.Name)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.FullName)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.HtmlUrl)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.Description)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.Url)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.Homepage)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.Language)
                .IsRequired(false);

            modelBuilder.Entity<GitHubRepository>()
                .Property(d => d.DefaultBranch)
                .IsRequired(false);
        }
    }
}