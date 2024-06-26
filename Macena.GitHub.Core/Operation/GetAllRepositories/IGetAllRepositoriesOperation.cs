using Macena.GitHub.Models.GetAllRepositories;

namespace Macena.GitHub.Core.Operation.GetAllRepositories
{
    /// <summary>
    /// Operation for fetching all GitHub repositories.
    /// </summary>
    public interface IGetAllRepositoriesOperation : IBaseOperation<GetAllRepositoriesRequest, GetAllRepositoriesResponse>
    {

    }
}