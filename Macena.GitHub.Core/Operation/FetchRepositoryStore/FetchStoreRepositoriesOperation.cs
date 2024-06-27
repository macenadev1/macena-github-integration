using System.Net.Http.Headers;
using Macena.GitHub.Core.ErrorCodes;
using Macena.GitHub.Core.Extensions;
using Macena.GitHub.Core.Mapping;
using Macena.GitHub.Core.Settings;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Models;
using Macena.GitHub.Models.FetchRepositoryStore;
using Macena.GitHub.Models.GitHubSearch;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Macena.GitHub.Models.GitHubSearch.GitHubSearchResponse;

namespace Macena.GitHub.Core.Operation.FetchRepositoryStore
{
    /// <summary>
    /// Operation for fetching and storing repositories.
    /// </summary>
    public class FetchStoreRepositoriesOperation :
        BaseOperation<FetchStoreRepositoriesRequest, FetchStoreRepositoriesResponse>,
        IFetchStoreRepositoriesOperation
    {

        /// <summary>
        /// HttpClient instance.
        /// </summary>
        readonly HttpClient _httpClient;

        /// <summary>s
        /// IAppSettings instance.
        /// </summary>
        readonly IAppSettings _appSettings;

        /// <summary>s
        /// IRepository instance.
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        readonly ILogger _logger;

        /// <summary>
        /// Name Application
        /// </summary>
        const string NAME_APP = "CSharpApp";

        public FetchStoreRepositoriesOperation(
            ILogger logger,
            HttpClient httpClient,
            IAppSettings settings,
            IRepository repository) : base(logger)
        {
            _httpClient = httpClient;
            _appSettings = settings;
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Processes the operation asynchronously.
        /// </summary>
        /// <param name="request">The request for fetching and storing repositories.</param>
        /// <returns>A FetchStoreRepositoriesResponse representing the processed operation result.</returns>
        protected override async Task<FetchStoreRepositoriesResponse> ProcessOperationAsync(FetchStoreRepositoriesRequest request)
        {
            _logger.LogDebug("initializes interaction over languages.");

            var tasks = request.Languages.Select(async language =>
            {
                _logger.LogDebug($"Processing with {language} language");
                var result = await this.GetTopRepositoriesAsync(language);

                foreach (var itemRepo in result)
                {
                    var itemConvert = itemRepo.Map();

                    bool existsRepo = await _repository.ExistsAsync(itemConvert.IdGitHub);

                    if (!existsRepo)
                    {
                        await _repository.AddAsync(itemConvert);
                    }
                }
            });

            await Task.WhenAll(tasks);

            return new FetchStoreRepositoriesResponse
            {
                Languages = request.Languages
            };
        }

        /// <summary>
        /// Retrieves the top repositories asynchronously based on the specified language.
        /// </summary>
        /// <param name="language">The programming language to search for.</param>
        /// <returns>A list of GitHubRepositoryItem representing the top repositories.</returns>
        public async Task<List<GitHubRepositoryItem>> GetTopRepositoriesAsync(string language)
        {
            try
            {
                this.MapHeader();

                var url = $"{_appSettings.BaseUrlLanguageGitHub}/search/repositories?q=language:{language}&sort=stars&order=desc";
                _logger.LogDebug($"Url for request: {url}");

                var response = await _httpClient.GetAsync(url);
                _logger.LogDebug($"Response with status {response.StatusCode}");

                await response.EnsureSuccessStatusCodeAsync();

                string content = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<GitHubSearchResponse>(content);
                return searchResult.Items;
            }
            catch (JsonException ex)
            {
                throw new Exception("Error parsing JSON response.", ex);
            }
        }

        /// <summary>
        /// Mapper Header
        /// </summary>
        private void MapHeader()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", NAME_APP);

            if (!string.IsNullOrEmpty(_appSettings.AccessTokenGitHub))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _appSettings.AccessTokenGitHub);
            }
        }

        /// <summary>
        /// Validates the operation asynchronously.
        /// </summary>
        /// <param name="request">The request for fetching and storing repositories.</param>
        /// <returns>An OperationResponse representing the validation result.</returns>
        public override async Task<OperationResponse> ValidateOperationAsync(FetchStoreRepositoriesRequest request)
        {
            return await Task.Run(() =>
            {
                var response = new FetchStoreRepositoriesResponse();

                if (request.Languages is null || request.Languages.Count == 0)
                {
                    if (_appSettings.DefaultLanguageSearch != null && _appSettings.DefaultLanguageSearch?.Count > 0)
                    {
                        request.Languages = _appSettings.DefaultLanguageSearch;
                    }
                    else
                    {
                        response.AddError(
                            (int)ErrorCodeEnum.FieldIsNullOrEmpty,
                            ErrorCodeEnum.FieldIsNullOrEmpty.Description(),
                            nameof(request.Languages));
                    }
                }

                return response;
            });
        }
    }
}
