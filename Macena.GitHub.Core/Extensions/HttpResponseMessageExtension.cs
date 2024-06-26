/// <summary>
/// Provides extension methods for HttpResponseMessage to ensure the HTTP request's success status code.
/// </summary>
public static class HttpResponseMessageExtension
{
    /// <summary>
    /// Ensures that the HTTP response has a successful status code. If not, throws an HttpRequestExceptionWithContent with details.
    /// </summary>
    /// <param name="response">The HttpResponseMessage to check for success status code.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestExceptionWithContent(
                $"The HTTP request failed with status code {response.StatusCode}. Content: {content}");
        }
    }
}

/// <summary>
/// Represents an HTTP request exception with content details.
/// </summary>
public class HttpRequestExceptionWithContent : HttpRequestException
{
    /// <summary>
    /// Initializes a new instance of the HttpRequestExceptionWithContent class with the specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the reason for the exception.</param>
    public HttpRequestExceptionWithContent(string message) : base(message) { }
}
