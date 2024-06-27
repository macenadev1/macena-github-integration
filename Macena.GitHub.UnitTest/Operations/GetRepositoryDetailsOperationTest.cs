using Macena.GitHub.Core.Operation.GetRepositoryDetails;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Entities;
using Macena.GitHub.Models.GetRepositoryDetails;
using Microsoft.Extensions.Logging;
using Moq;

namespace Macena.GitHub.UnitTest.Operations
{
    public class GetRepositoryDetailsOperationTest
    {
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<ILogger<GetRepositoryDetailsOperation>> _loggerMock;
        private readonly GetRepositoryDetailsOperation _operation;

        public GetRepositoryDetailsOperationTest()
        {
            _repositoryMock = new Mock<IRepository>();
            _loggerMock = new Mock<ILogger<GetRepositoryDetailsOperation>>();
            _operation = new GetRepositoryDetailsOperation(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task ProcessOperationAsync_ShouldFetchRepositoryDetails()
        {
            // Arrange
            var request = new GetRepositoryDetailsRequest
            {
                Id = 1
            };

            var repository = new GitHubRepository
            {
                IdGitHub = 1,
                Name = "TestRepo"
            };

            _repositoryMock.Setup(r => r.GetByIdAsync(request.Id))
                .ReturnsAsync(repository);

            // Act
            var response = await _operation.ProcessAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.GitHubRepositoryItem);
            Assert.Equal(request.Id, response.GitHubRepositoryItem.Id);
        }
    }
}