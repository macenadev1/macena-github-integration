namespace Macena.GitHub.Models
{
    /// <summary>
    /// Represents information about an operation result, including error details.
    /// </summary>
    public class OperationResultInfo
    {
        /// <summary>
        /// The error code associated with the result.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// The message describing the result or error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The field associated with the error, if applicable.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Default constructor for OperationResultInfo.
        /// </summary>
        public OperationResultInfo() { }
        
        /// <summary>
        /// Initializes a new instance of the OperationResultInfo class with an error code and message.
        /// </summary>
        /// <param name="errorCode">The error code associated with the result.</param>
        /// <param name="message">The message describing the result or error.</param>
        public OperationResultInfo(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the OperationResultInfo class with an error code, message, and field.
        /// </summary>
        /// <param name="errorCode">The error code associated with the result.</param>
        /// <param name="message">The message describing the result or error.</param>
        /// <param name="field">The field associated with the error.</param>
        public OperationResultInfo(int errorCode, string message, string field)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
            this.Field = field;
        }
    }
}
