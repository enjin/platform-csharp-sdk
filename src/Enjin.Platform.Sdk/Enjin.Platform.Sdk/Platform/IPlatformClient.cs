using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for platform clients to implement.
/// </summary>
[PublicAPI]
public interface IPlatformClient : IDisposable
{
    /// <summary>
    /// The base address of the platform used by this client.
    /// </summary>
    Uri BaseAddress { get; }

    /// <summary>
    /// Property indicating whether this client has an authentication token.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// The value of the User-Agent header this client uses in requests to the platform.
    /// </summary>
    string UserAgent { get; }

    /// <summary>
    /// Sets the authentication token to be used by this client.
    /// </summary>
    /// <param name="token">The authentication token.</param>
    void Auth(string token);

    /// <summary>
    /// Sends the given platform request.
    /// </summary>
    /// <param name="request">The platform request.</param>
    /// <typeparam name="TResult">The type of the result in the response.</typeparam>
    /// <returns>The task containing the response.</returns>
    Task<IPlatformResponse<TResult>> SendRequest<TResult>(IPlatformRequest request);
}
