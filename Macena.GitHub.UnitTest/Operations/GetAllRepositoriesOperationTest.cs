using Macena.GitHub.Core.Operation.GetAllRepositories;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Entities;
using Macena.GitHub.Models.GetAllRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Macena.GitHub.UnitTest.Operations
{
    public class GetAllRepositoriesOperationTest
    {
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<ILogger<GetAllRepositoriesOperation>> _loggerMock;
        private readonly GetAllRepositoriesOperation _operation;

        public GetAllRepositoriesOperationTest()
        {
            _repositoryMock = new Mock<IRepository>();
            _loggerMock = new Mock<ILogger<GetAllRepositoriesOperation>>();
            _operation = new GetAllRepositoriesOperation(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task ProcessOperationAsync_ShouldFetchAllRepositories()
        {
            // Arrange
            var request = new GetAllRepositoriesRequest
            {
                Language = "C#",
                Page = 1,
                PageSize = 10
            };

            var repositories = new List<GitHubRepository>
            {
                new GitHubRepository { IdGitHub = 1, Name = "Repo1" },
                new GitHubRepository { IdGitHub = 2, Name = "Repo2" }
            };

            _repositoryMock.Setup(r => r.GetAllAsync(request.Language, request.Page, request.PageSize))
                .ReturnsAsync(repositories);

            // Act
            var response = await _operation.ProcessAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(2, response.GitHubRepositoryItem.Count);
        }
    }
}