using Newtonsoft.Json;

namespace Macena.GitHub.Models
{
    /// <summary>
    /// Base class for any request
    /// </summary>
    public class OperationRequest
    {
        /// <summary>
        /// Default Contructor.
        /// </summary>
        public OperationRequest()
        {

        }

        /// <summary>
        /// Returns the Object as JSON string.
        /// </summary>
        /// <returns>Object as JSON representations.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}