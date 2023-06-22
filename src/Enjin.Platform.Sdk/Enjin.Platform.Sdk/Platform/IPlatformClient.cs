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
    public Uri BaseAddress { get; }

    /// <summary>
    /// Property indicating whether this client has an authentication token.
    /// </summary>
    public bool IsAuthenticated { get; }

    /// <summary>
    /// The value of the User-Agent header this client uses in requests to the platform.
    /// </summary>
    public string UserAgent { get; }

    /// <summary>
    /// Sets the authentication token to be used by this client.
    /// </summary>
    /// <param name="token">The authentication token.</param>
    public void Auth(string token);

    /// <summary>
    /// Sends the given platform request.
    /// </summary>
    /// <param name="request">The platform request.</param>
    /// <typeparam name="T">The type of the result in the response.</typeparam>
    /// <returns>The task containing the response.</returns>
    public Task<IPlatformResponse<T>> SendRequest<T>(IPlatformRequest request);
}