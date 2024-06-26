using Newtonsoft.Json;

namespace Macena.GitHub.Models
{
    /// <summary>
    /// Base class for any Response.
    /// </summary>
    public class OperationResponse
    {
        /// <summary>
        /// Indicates whether the operation was successful.
        /// </summary>
        public virtual bool Success => this.Errors?.Any() == false;

        /// <summary>
        /// List of errors that occurred during the operation.
        /// </summary>
        public virtual List<OperationResultInfo> Errors { get; set; }

        /// <summary>
        /// Default constructor for OperationResponse.
        /// </summary>
        public OperationResponse()
        {
            this.Errors = new List<OperationResultInfo>();
        }

        /// <summary>
        /// Returns the object as a JSON string.
        /// </summary>
        /// <returns>Object as a JSON representation.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Adds an error to the Errors list.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The error message.</param>
        public void AddError(int errorCode, string message)
        {
            this.Errors.Add(new OperationResultInfo(errorCode, message));
        }

        /// <summary>
        /// Adds an error with a specified field to the Errors list.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="message">The error message.</param>
        /// <param name="field">The field associated with the error.</param>
        public void AddError(int errorCode, string message, string field)
        {
            this.Errors.Add(new OperationResultInfo(errorCode, message, field));
        }
    }

    /// <summary>
    /// Represents an operation response with additional data of type T.
    /// </summary>
    /// <typeparam name="T">The type of data in the response.</typeparam>
    public class OperationResponse<T> : OperationResponse
    {
        /// <summary>
        /// The additional data in the response.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Default constructor for OperationResponse with additional data.
        /// </summary>
        public OperationResponse() { }

        /// <summary>
        /// Initializes a new instance of the OperationResponse class with additional data.
        /// </summary>
        /// <param name="data">The additional data to include in the response.</param>
        public OperationResponse(T data)
        {
            this.Data = data;
        }
    }
}
