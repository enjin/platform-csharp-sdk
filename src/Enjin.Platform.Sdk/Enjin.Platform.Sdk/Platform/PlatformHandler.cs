using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A HTTP handler used by <see cref="PlatformClient"/> for processing HTTP traffic to and from the platform.
/// </summary>
/// <seealso cref="PlatformClient"/>
[PublicAPI]
public sealed class PlatformHandler : DelegatingHandler
{
    private string? _authToken;

    // Mutexes
    private readonly object _authMutex = new();

    /// <summary>
    /// Property indicating whether this handler has an authentication token.
    /// </summary>
    public bool HasAuthToken
    {
        get
        {
            lock (_authMutex)
            {
                return !string.IsNullOrWhiteSpace(_authToken);
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformHandler"/> class with the given inner handler.
    /// </summary>
    /// <inheritdoc/>
    internal PlatformHandler(HttpMessageHandler innerHandler) : base(innerHandler)
    {
    }

    /// <summary>
    /// Sets the authentication token for this handler.
    /// </summary>
    /// <param name="token">The authentication token.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if token is <c>null</c>.
    /// </exception>
    public void SetAuthToken(string token)
    {
        if (token == null)
        {
            throw new ArgumentNullException(nameof(token));
        }

        lock (_authMutex)
        {
            _authToken = token;
        }
    }

    #region DelegatingHandler

    /// <summary>
    /// Sets the value of the <c>Authorization</c> header if <see cref="HasAuthToken"/> is <c>true</c> and then passes
    /// the request to the inner handler.
    /// </summary>
    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                 CancellationToken cancellationToken)
    {
        lock (_authMutex)
        {
            if (HasAuthToken)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(_authToken ?? throw new InvalidOperationException("Auth token is null or empty"));
            }
        }

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    #endregion DelegatingHandler
}