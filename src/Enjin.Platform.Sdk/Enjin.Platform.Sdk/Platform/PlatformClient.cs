using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Client class for sending and receiving data with the platform.
/// </summary>
[PublicAPI]
public sealed class PlatformClient : IPlatformClient
{
    private readonly PlatformHandler _handler;
    private readonly HttpClient _httpClient;
    private readonly ILogger? _logger;

    // Mutexes
    private readonly object _disposeMutex = new();

    /// <summary>
    /// Internal property representing whether this client has been disposed.
    /// </summary>
    private bool IsDisposed { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformClient"/> class.
    /// </summary>
    /// <param name="baseAddress">The base address of the platform hosting the client.</param>
    /// <param name="userAgent">The value for the User-Agent header.</param>
    /// <param name="logger">The logger for the client.</param>
    /// <param name="httpLogLevel">The <see cref="HttpLogLevel"/> for HTTP traffic.</param>
    private PlatformClient(Uri baseAddress, string userAgent, ILogger? logger, HttpLogLevel httpLogLevel)
    {
        BaseAddress = baseAddress;
        UserAgent = userAgent;

        _logger = logger;
        _handler = CreateHandler(httpLogLevel);
        _httpClient = CreateHttpClient();
    }

    /// <summary>
    /// Creates a new handler to be used by this client.
    /// </summary>
    /// <returns>The handler.</returns>
    private PlatformHandler CreateHandler(HttpLogLevel httpLogLevel)
    {
        HttpMessageHandler innerHandler = new HttpClientHandler();

        if (_logger != null && httpLogLevel != HttpLogLevel.None)
        {
            innerHandler = new HttpLoggingHandler(innerHandler, _logger, httpLogLevel);
        }

        return new PlatformHandler(innerHandler);
    }

    /// <summary>
    /// Creates a new HTTP client to be used by this client.
    /// </summary>
    /// <returns>The HTTP client.</returns>
    private HttpClient CreateHttpClient()
    {
        HttpClient client = new HttpClient(_handler)
        {
            BaseAddress = BaseAddress,
        };

        client.DefaultRequestHeaders.UserAgent.TryParseAdd(UserAgent);

        return client;
    }

    /// <summary>
    /// Creates a builder instance to be used for creating an instance of <see cref="PlatformClient"/>.
    /// </summary>
    /// <returns>The builder instance.</returns>
    public static PlatformClientBuilder Builder() => new();

    #region IDisposable

    /// <inheritdoc/>
    public void Dispose()
    {
        lock (_disposeMutex)
        {
            if (IsDisposed)
            {
                return;
            }

            _httpClient.Dispose();
            IsDisposed = true;
        }
    }

    #endregion IDisposable

    #region IPlatformClient

    /// <inheritdoc/>
    public Uri BaseAddress { get; }

    /// <inheritdoc/>
    public bool IsAuthenticated => _handler.HasAuthToken;

    /// <inheritdoc/>
    public string UserAgent { get; }

    /// <inheritdoc/>
    public void Auth(string token)
    {
        _handler.SetAuthToken(token);
    }

    /// <inheritdoc/>
    public Task<IPlatformResponse<TResult>> SendRequest<TResult>(IPlatformRequest request)
    {
        Uri uri = new Uri(_httpClient.BaseAddress, request.Path);

        return _httpClient.PostAsync(uri, request.Content).ContinueWith(task =>
        {
            HttpResponseMessage? httpRes = task.Result;

            try
            {
                string content = httpRes.Content.ReadAsStringAsync().Result;
                TResult result = JsonSerializer.Deserialize<TResult>(content)!;
                IPlatformResponse<TResult> res = new PlatformResponse<TResult>(httpRes.StatusCode,
                                                                               httpRes.Headers,
                                                                               result);

                return res;
            }
            catch (Exception e)
            {
                _logger?.Log(LogLevel.Error, e, "Error while processing platform response");
                throw;
            }
            finally
            {
                httpRes?.Dispose();
            }
        });
    }

    #endregion IPlatformClient

    /// <summary>
    /// The builder class for defining and creating a new instance of the <see cref="PlatformClient"/> class.
    /// </summary>
    [PublicAPI]
    public sealed class PlatformClientBuilder
    {
        private Uri? _baseAddress;
        private HttpLogLevel? _httpLogLevel;
        private ILogger? _logger;
        private string? _userAgent;

        private static readonly string DEFAULT_USER_AGENT;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformClientBuilder"/> class.
        /// </summary>
        internal PlatformClientBuilder()
        {
        }

        static PlatformClientBuilder()
        {
            string? version = typeof(PlatformClient).Assembly
                                                    .GetCustomAttributes<AssemblyInformationalVersionAttribute>()
                                                    .First()
                                                    .InformationalVersion;
            string userAgentVersion = version.Split('+')[0];

            DEFAULT_USER_AGENT = $"Platform Enjin CSharp SDK v{userAgentVersion}";
        }

        /// <summary>
        /// Builds an instance of <see cref="PlatformClient"/> using the set parameters.
        /// </summary>
        /// <returns>The client instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the base address is <c>null</c> at the time this method is called.
        /// </exception>
        public PlatformClient Build()
        {
            if (_baseAddress == null)
            {
                throw new InvalidOperationException($"Cannot build {nameof(PlatformClient)} without a base address");
            }

            string userAgent = _userAgent ?? DEFAULT_USER_AGENT;
            HttpLogLevel httpLogLevel = _httpLogLevel ?? HttpLogLevel.None;

            return new PlatformClient(_baseAddress, userAgent, _logger, httpLogLevel);
        }

        /// <summary>
        /// Sets the <see cref="Uri"/> for the client to use as the base address for the platform.
        /// </summary>
        /// <param name="baseAddress">The base address as a <see cref="Uri"/>.</param>
        /// <returns>This builder for chaining.</returns>
        public PlatformClientBuilder SetBaseAddress(Uri baseAddress)
        {
            _baseAddress = baseAddress;
            return this;
        }

        /// <summary>
        /// Sets the base address for the platform for the client to use from a URI string.
        /// </summary>
        /// <param name="baseAddress">The base address as a URI string.</param>
        /// <returns>This builder for chaining.</returns>
        public PlatformClientBuilder SetBaseAddress(string baseAddress)
        {
            _baseAddress = new Uri(baseAddress);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="HttpLogLevel"/> for the client to use when processing HTTP traffic.
        /// </summary>
        /// <param name="httpLogLevel">The <see cref="HttpLogLevel"/>.</param>
        /// <returns>This builder for chaining.</returns>
        /// <remarks>
        /// This setting will have no effect if a logger is not supplied through <see cref="SetLogger"/>.
        /// </remarks>
        public PlatformClientBuilder SetHttpLogLevel(HttpLogLevel httpLogLevel)
        {
            _httpLogLevel = httpLogLevel;
            return this;
        }

        /// <summary>
        /// Sets the logger for the client to use.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <returns>This builder for chaining.</returns>
        public PlatformClientBuilder SetLogger(ILogger? logger)
        {
            _logger = logger;
            return this;
        }

        /// <summary>
        /// Sets the value of the User-Agent header that the client will use when sending requests to the platform.
        /// </summary>
        /// <param name="userAgent">The User-Agent value.</param>
        /// <returns>This builder for chaining.</returns>
        /// <remarks>
        /// If this value is not set when the client is built, then the User-Agent will be supplied as
        /// <c>Platform Enjin CSharp SDK v{SDK_VERSION}</c>.
        /// </remarks>
        public PlatformClientBuilder SetUserAgent(string userAgent)
        {
            _userAgent = userAgent;
            return this;
        }
    }
}