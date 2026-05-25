using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.Platform.Sdk;

/// <summary>
/// HTTP client for sending GraphQL operations to an Enjin Platform v3 endpoint.
/// </summary>
[PublicAPI]
public sealed class PlatformClient : IPlatformClient
{
    private const string DefaultUserAgent = "Enjin.Platform.Sdk/3.0.0";

    private readonly HttpClient _httpClient;
    private readonly PlatformHandler _platformHandler;
    private bool _disposed;

    /// <inheritdoc/>
    public Uri BaseAddress => _httpClient.BaseAddress
                              ?? throw new InvalidOperationException("BaseAddress is not set.");

    /// <inheritdoc/>
    public bool IsAuthenticated => _platformHandler.HasAuthToken;

    /// <inheritdoc/>
    public string UserAgent { get; }

    /// <summary>
    /// Initializes a new <see cref="PlatformClient"/>.
    /// </summary>
    /// <param name="baseAddress">The base address of the platform's GraphQL endpoint (e.g. <c>https://platform.enjin.io/graphql</c>).</param>
    /// <param name="userAgent">Optional User-Agent header value. Defaults to <c>Enjin.Platform.Sdk/3.0.0</c>.</param>
    /// <param name="logger">Optional logger; when provided HTTP traffic is logged at the given <paramref name="httpLogLevel"/>.</param>
    /// <param name="httpLogLevel">HTTP log level. Ignored when <paramref name="logger"/> is <c>null</c>.</param>
    public PlatformClient(Uri baseAddress,
                          string? userAgent = null,
                          ILogger? logger = null,
                          HttpLogLevel httpLogLevel = HttpLogLevel.None)
    {
        if (baseAddress == null)
        {
            throw new ArgumentNullException(nameof(baseAddress));
        }

        UserAgent = userAgent ?? DefaultUserAgent;

        HttpMessageHandler inner = new HttpClientHandler();
        if (logger != null && httpLogLevel != HttpLogLevel.None)
        {
            inner = new HttpLoggingHandler(inner, logger, httpLogLevel);
        }

        _platformHandler = new PlatformHandler(inner);
        _httpClient = new HttpClient(_platformHandler)
        {
            BaseAddress = baseAddress,
        };
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    /// <inheritdoc/>
    public void Auth(string token)
    {
        if (token == null)
        {
            throw new ArgumentNullException(nameof(token));
        }

        _platformHandler.SetAuthToken(token);
    }

    /// <inheritdoc/>
    public Task<IPlatformResponse<TResult>> SendRequest<TResult>(IPlatformRequest request)
    {
        return SendRequest<TResult>(request, CancellationToken.None);
    }

    /// <summary>
    /// Sends the given <paramref name="request"/> to the platform and deserializes the response body as <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="request">The platform request.</param>
    /// <param name="cancellationToken">Token to observe for cancellation.</param>
    /// <typeparam name="TResult">The expected response body type.</typeparam>
    /// <returns>The platform response.</returns>
    public async Task<IPlatformResponse<TResult>> SendRequest<TResult>(IPlatformRequest request,
                                                                       CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        using HttpRequestMessage message = new(HttpMethod.Post, request.Path)
        {
            Content = request.Content,
        };

        using HttpResponseMessage response = await _httpClient
            .SendAsync(message, cancellationToken)
            .ConfigureAwait(false);

        string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        TResult result = JsonConvert.DeserializeObject<TResult>(body)!;

        return new PlatformResponse<TResult>(response.StatusCode, response.Headers, result);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _httpClient.Dispose();
        _disposed = true;
    }
}
