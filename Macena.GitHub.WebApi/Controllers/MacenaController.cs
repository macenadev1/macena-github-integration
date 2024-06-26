using System.Net;
using Macena.GitHub.Core.ErrorCodes;
using Macena.GitHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Macena.GitHub.WebApi.Controllers
{
    /// <summary>
    /// Base controllers
    /// </summary>
    /// <typeparam name="TLogger">Type Logger operation</typeparam>
    [ApiController]
    abstract public class MacenaController<TLogger> : Controller
    {
        /// <summary>
        /// Controller Logger
        /// </summary>
        protected ILogger<TLogger> _logger;

        /// <summary>
        /// Default constructor 
        /// </summary>
        /// <param name="logger"></param>
        public MacenaController(ILogger<TLogger> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Generates an appropriate HTTP response based on the operation performed and the response obtained.
        /// </summary>
        /// <typeparam name="TResponse">Type of operation response.</typeparam>
        /// <param name="response">Operation response.</param>
        /// <returns>An IActionResult representing the HTTP response.</returns>
        public ActionResult GetActionResult<TResponse>(OperationResponse response)
        {
            if (response.Errors.Any(e => e.ErrorCode == (int)ErrorCodeEnum.UnexpectedError))
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError, null);
            }
            else if (!response.Success)
            {
                return this.BadRequest(response);
            }

            return this.Ok(response);
        }
    }
}