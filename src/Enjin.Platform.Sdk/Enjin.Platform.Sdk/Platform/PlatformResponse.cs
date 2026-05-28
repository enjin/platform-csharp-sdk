using System.Net;
using System.Net.Http.Headers;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Contains HTTP data that the platform sent in response to a request.
/// </summary>
/// <typeparam name="TResult">The type of the result in the response.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="PlatformResponse{TResult}"/> class.
/// </remarks>
/// <param name="statusCode">The HTTP status code for the response.</param>
/// <param name="headers">The HTTP headers for the response.</param>
/// <param name="result">The result for the response.</param>
[PublicAPI]
public sealed class PlatformResponse<TResult>(
    HttpStatusCode statusCode,
    HttpResponseHeaders headers,
    TResult result
) : IPlatformResponse<TResult>
{
    /// <inheritdoc/>
    public TResult Result { get; } = result;

    /// <inheritdoc/>
    public HttpResponseHeaders Headers { get; } = headers;

    /// <inheritdoc/>
    public bool IsSuccessStatusCode => (int)StatusCode is >= 200 and < 300;

    /// <inheritdoc/>
    public HttpStatusCode StatusCode { get; } = statusCode;
}
