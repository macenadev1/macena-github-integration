using Macena.GitHub.Core.Operation.FetchRepositoryStore;
using Macena.GitHub.Core.Operation.GetAllRepositories;
using Macena.GitHub.Core.Operation.GetRepositoryDetails;
using Macena.GitHub.Core.Settings;
using Macena.GitHub.DomainInterfaces;
using Macena.GitHub.Models;
using Macena.GitHub.Models.FetchRepositoryStore;
using Macena.GitHub.Models.GetAllRepositories;
using Macena.GitHub.Models.GetRepositoryDetails;
using Microsoft.AspNetCore.Mvc;

namespace Macena.GitHub.WebApi.Controllers
{
    /// <summary>
    /// Controller that executes Language Repositories GitHub.
    /// </summary>
    [ApiController]
    [Route("api/repositories")]
    public class LanguageRepositoryController : MacenaController<LanguageRepositoryController>
    {
        private readonly IAppSettings _appSettings;

        private readonly IRepository _repository;

        /// <summary>
        /// Constructor Language Repository Controller
        /// </summary>
        /// <param name="logger">Instance ILogger</param>
        /// <param name="appSettings">Instance IAppSettings</param>
        /// <param name="repository">Instance repository</param>
        public LanguageRepositoryController(
            ILogger<LanguageRepositoryController> logger,
            IAppSettings appSettings,
            IRepository repository)
            : base(logger)
        {
            _appSettings = appSettings;
            _repository = repository;
        }

        /// <summary>
        /// Handles the HTTP POST request for fetching and storing repositories.
        /// </summary>
        /// <param name="request">If no programming languages are specified, the following default values will be used: "C#", "JavaScript", "Python", "C", "Java".</param>
        /// <returns>The languages ​​registered successfully.</returns>
        /// <response code="200">Returns the languages ​​registered successfully.</response>
        [HttpPost("fetch-and-store")]
        public async Task<IActionResult> FetchAndStoreRepositories([FromBody] FetchStoreRepositoriesRequest request)
        {
            var operation = new FetchStoreRepositoriesOperation(
                _logger,
                new HttpClient(),
                _appSettings,
                _repository);

            var result = await operation.ProcessAsync(request);

            return this.GetActionResult<FetchStoreRepositoriesResponse>(result);
        }

        /// <summary>
        /// Lists GitHub repositories with optional filters and pagination.
        /// </summary>
        /// <param name="filter">Optional filter parameters.</param>
        /// <returns>A list of GitHub repositories.</returns>
        /// <response code="200">A list of GitHub repositories.</response>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetAllRepositoriesRequest filter)
        {
            var operation = new GetAllRepositoriesOperation(_logger, _repository);

            var result = await operation.ProcessAsync(filter);

            return this.GetActionResult<OperationResponse>(result);
        }

        /// <summary>
        /// Gets the details of a specific GitHub repository.
        /// </summary>
        /// <param name="id">The unique identifier of the repository.</param>
        /// <returns>The details of the specified GitHub repository.</returns>
        /// <response code="200">The details of the specified GitHub repository.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRepositoryDetails(int id)
        {
            var operation = new GetRepositoryDetailsOperation(_logger, _repository);

            var request = new GetRepositoryDetailsRequest
            {
                Id = id
            };

            var result = await operation.ProcessAsync(request);

            return this.GetActionResult<OperationResponse>(result);
        }
    }
}