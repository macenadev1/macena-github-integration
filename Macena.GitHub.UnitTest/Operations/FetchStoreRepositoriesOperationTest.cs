using System.Net;
using Macena.GitHub.Core.Operation.FetchRepositoryStore;
using Macena.GitHub.Core.Settings;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Entities;
using Macena.GitHub.Models.FetchRepositoryStore;
using Macena.GitHub.Models.GitHubSearch;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.UnitTest.Operations
{
    public class FetchStoreRepositoriesOperationTest
    {

        private readonly Mock<ILogger<FetchStoreRepositoriesOperation>> _loggerMock;
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly Mock<IAppSettings> _appSettingsMock;
        private readonly Mock<IRepository> _repositoryMock;
        private readonly FetchStoreRepositoriesOperation _operation;

        public FetchStoreRepositoriesOperationTest()
        {
            _loggerMock = new Mock<ILogger<FetchStoreRepositoriesOperation>>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _appSettingsMock = new Mock<IAppSettings>();
            _repositoryMock = new Mock<IRepository>();
            
            _operation = new FetchStoreRepositoriesOperation(
                _loggerMock.Object,
                _httpClient,
                _appSettingsMock.Object,
                _repositoryMock.Object);
        }

        [Fact]
        public async Task ProcessOperationAsync_ShouldFetchAndStoreRepositories()
        {
            // Arrange
            var request = new FetchStoreRepositoriesRequest
            {
                Languages = new List<string> { "C#" }
            };

            var gitHubRepositories = new List<GitHubRepositoryItem>
        {
            new GitHubRepositoryItem { Id = 1, Name = "Repo1" },
            new GitHubRepositoryItem { Id = 2, Name = "Repo2" }
        };

            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(new GitHubSearchResponse { Items = gitHubRepositories }))
                });

            _appSettingsMock.SetupGet(x => x.BaseUrlLanguageGitHub).Returns("https://api.github.com");
            _repositoryMock.Setup(x => x.ExistsAsync(It.IsAny<int>())).ReturnsAsync(false);
            _repositoryMock.Setup(x => x.AddAsync(It.IsAny<GitHubRepository>()))
            .ReturnsAsync(1);

            // Act
            var response = await _operation.ProcessAsync(request);

            // Assert
            Assert.NotNull(response);
            _httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
            _repositoryMock.Verify(x => x.AddAsync(It.IsAny<GitHubRepository>()), Times.Exactly(gitHubRepositories.Count));
        }

        [Fact]
        public async Task ValidateOperationAsync_ShouldReturnErrorResponse_WhenLanguagesAreNull()
        {
            // Arrange
            var request = new FetchStoreRepositoriesRequest
            {
                Languages = null
            };

            _appSettingsMock.SetupGet(x => x.DefaultLanguageSearch).Returns(new List<string> { "C#" });

            // Act
            var response = await _operation.ValidateOperationAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.Empty(response.Errors);
        }

        [Fact]
        public async Task ValidateOperationAsync_ShouldReturnErrorResponse_WhenLanguagesAreEmpty()
        {
            // Arrange
            var request = new FetchStoreRepositoriesRequest
            {
                Languages = new List<string>()
            };

            _appSettingsMock.SetupGet(x => x.DefaultLanguageSearch).Returns((List<string>)null);

            // Act
            var response = await _operation.ValidateOperationAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Errors);
        }
    }
}