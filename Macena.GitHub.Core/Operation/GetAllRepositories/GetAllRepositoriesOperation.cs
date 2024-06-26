using Macena.GitHub.Core.Mapping;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Models.GetAllRepositories;
using Microsoft.Extensions.Logging;

namespace Macena.GitHub.Core.Operation.GetAllRepositories
{
    /// <summary>
    /// Operation for fetching all GitHub repositories.
    /// </summary>
    public class GetAllRepositoriesOperation : BaseOperation<GetAllRepositoriesRequest, GetAllRepositoriesResponse>,
        IGetAllRepositoriesOperation
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRepositoriesOperation"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="repository">The repository service.</param>
        public GetAllRepositoriesOperation(ILogger logger, IRepository repository) : base(logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Processes the operation asynchronously.
        /// </summary>
        /// <param name="request">The request for fetching all repositories.</param>
        /// <returns>A GetAllRepositoriesResponse representing the processed operation result.</returns>
        protected override async Task<GetAllRepositoriesResponse> ProcessOperationAsync(GetAllRepositoriesRequest request)
        {
            _logger.LogInformation("Fetching all repositories operation started.");

            var repositories = await _repository.GetAllAsync(request.Language, request.Page, request.PageSize);
            _logger.LogInformation($"Fetched {repositories.Count} repositories.");

            var response = new GetAllRepositoriesResponse
            {
                GitHubRepositoryItem = repositories.Select(r => r.Map()).ToList()
            };

            _logger.LogInformation("Fetching all repositories operation completed.");
            return response;
        }
    }
}
