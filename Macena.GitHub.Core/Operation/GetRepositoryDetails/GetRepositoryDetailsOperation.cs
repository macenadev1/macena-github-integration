using Macena.GitHub.Core.Mapping;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Models.GetRepositoryDetails;
using Microsoft.Extensions.Logging;

namespace Macena.GitHub.Core.Operation.GetRepositoryDetails
{
    /// <summary>
    /// Operation for retrieving details of a repository.
    /// </summary>
    public class GetRepositoryDetailsOperation : BaseOperation<GetRepositoryDetailsRequest, GetRepositoryDetailsResponse>,
        IGetRepositoryDetailsOperation
    {
        /// <summary>
        /// Repository instance.
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRepositoryDetailsOperation"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="repository">The repository service.</param>
        public GetRepositoryDetailsOperation(ILogger logger, IRepository repository) : base(logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Processes the operation asynchronously to retrieve repository details.
        /// </summary>
        /// <param name="request">The request containing the repository ID.</param>
        /// <returns>A response containing the details of the repository.</returns>
        protected override async Task<GetRepositoryDetailsResponse> ProcessOperationAsync(GetRepositoryDetailsRequest request)
        {
            _logger.LogDebug($"Fetching details for repository with ID: {request.Id}");
            var repository = await _repository.GetByIdAsync(request.Id);

            _logger.LogDebug($"Repository details fetched successfully for ID: {request.Id}");
            var response = new GetRepositoryDetailsResponse
            {
                GitHubRepositoryItem = repository.Map()
            };

            return response;
        }
    }
}