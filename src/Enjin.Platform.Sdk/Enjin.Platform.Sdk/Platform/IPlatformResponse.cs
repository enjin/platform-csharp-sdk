using System.Net;
using System.Net.Http.Headers;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for a response containing HTTP data that the platform sent in response to a request.
/// </summary>
/// <typeparam name="TResult">The type of the result in the response.</typeparam>
[PublicAPI]
public interface IPlatformResponse<out TResult>
{
    /// <summary>
    /// The result that represent the body of this response.
    /// </summary>
    public TResult Result { get; }

    /// <summary>
    /// The HTTP headers of this response.
    /// </summary>
    public HttpResponseHeaders Headers { get; }

    /// <summary>
    /// Whether the <see cref="StatusCode"/> property of this response is in the range of 200-299 inclusive.
    /// </summary>
    public bool IsSuccessStatusCode { get; }

    /// <summary>
    /// The status code of this response.
    /// </summary>
    public HttpStatusCode StatusCode { get; }
}