using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Delegating handler for logging HTTP traffic.
/// </summary>
internal class HttpLoggingHandler : DelegatingHandler
{
    private readonly HttpLogLevel _httpLogLevel;
    private readonly ILogger _logger;

    private const int InitialBuilderSize = 1000;
    private const LogLevel TraceLevel = LogLevel.Trace;

    // Separators
    private const string CommaSeparator = ", ";
    private const string SpaceSeparator = " ";

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpLoggingHandler"/> class with the given inner handler.
    /// </summary>
    /// <param name="innerHandler">
    /// The inner handler which is responsible for processing the HTTP response messages.
    /// </param>
    /// <param name="logger">The logger.</param>
    /// <param name="httpLogLevel">The <see cref="HttpLogLevel"/>.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if httpLogLevel is <see cref="HttpLogLevel.None"/>.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if logger is <c>null</c>.
    /// </exception>
    public HttpLoggingHandler(HttpMessageHandler innerHandler, ILogger logger, HttpLogLevel httpLogLevel)
        : base(innerHandler)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        if (httpLogLevel == HttpLogLevel.None)
        {
            throw new ArgumentException($"{nameof(httpLogLevel)} cannot be {nameof(HttpLogLevel.None)}");
        }

        _httpLogLevel = httpLogLevel;
    }

    /// <summary>
    /// Logs the given request message.
    /// </summary>
    /// <param name="request">The request message.</param>
    /// <param name="builder">The string builder to compile the log with.</param>
    private void LogRequest(HttpRequestMessage request, StringBuilder builder)
    {
        builder.Clear();

        // Essential info
        string method = request.Method.Method.ToUpper();
        string uri = request.RequestUri.ToString();
        long? contentLength = request.Content.Headers.ContentLength;

        // Basic
        if (_httpLogLevel == HttpLogLevel.Basic)
        {
            builder.Append("--> ").Append(method).Append(" ").Append(uri)
                   .Append(" (").Append(contentLength).Append("-byte body)");

            _logger.Log(TraceLevel, builder.ToString());

            return;
        }

        builder.Append("--> ").Append(method).Append(" ").AppendLine(uri);

        // Headers
        foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
        {
            string? key = header.Key;
            IEnumerable<string>? values = header.Value;

            if (key == null || values == null)
            {
                continue;
            }

            string valuesSeparator = key.Equals("User-Agent") ? SpaceSeparator : CommaSeparator;
            builder.Append(key).Append(": ").AppendLine(string.Join(valuesSeparator, values));
        }

        if (_httpLogLevel == HttpLogLevel.Headers)
        {
            builder.Append("<-- END ").Append(method).Append(contentLength).Append("-byte body)");

            _logger.Log(TraceLevel, builder.ToString());

            return;
        }

        // Body
        builder.AppendLine() // Line break between header(s) and body
               .AppendLine(request.Content.ReadAsStringAsync().Result)
               .Append("<-- END ").Append(method).Append(" (").Append(contentLength).Append("-byte body)");

        _logger.Log(TraceLevel, builder.ToString());
    }

    /// <summary>
    /// Logs the given response message.
    /// </summary>
    /// <param name="response">The response message.</param>
    /// <param name="rtt">The round-trip time of the message.</param>
    /// <param name="builder">The string builder to compile the log with.</param>
    private void LogResponse(HttpResponseMessage response, int rtt, StringBuilder builder)
    {
        builder.Clear();

        // Essential info
        int statusCode = (int)response.StatusCode;
        string uri = response.RequestMessage.RequestUri.ToString();

        // Basic
        builder.Append("<-- ").Append(statusCode).Append(" ").Append(uri).Append(" (").Append(rtt).Append("ms)");

        if (_httpLogLevel == HttpLogLevel.Basic)
        {
            _logger.Log(TraceLevel, builder.ToString());

            return;
        }

        builder.AppendLine();

        // Headers
        foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
        {
            string? key = header.Key;
            IEnumerable<string>? values = header.Value;

            if (key == null || values == null)
            {
                continue;
            }

            builder.Append(key).Append(": ").AppendLine(string.Join(CommaSeparator, values));
        }

        if (_httpLogLevel == HttpLogLevel.Headers)
        {
            builder.Append("<-- END HTTP");

            _logger.Log(TraceLevel, builder.ToString());

            return;
        }

        // Body
        builder.AppendLine() // Line break between header(s) and body
               .AppendLine(response.Content.ReadAsStringAsync().Result)
               .Append("<-- END HTTP");

        _logger.Log(TraceLevel, builder.ToString());
    }

    #region DelegatingHandler

    /// <summary>
    /// Handles logging the request and response.
    /// </summary>
    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                 CancellationToken cancellationToken)
    {
        if (_httpLogLevel == HttpLogLevel.None)
        {
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        StringBuilder builder = new(InitialBuilderSize);

        LogRequest(request, builder);

        DateTimeOffset start = DateTimeOffset.Now;
        HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        DateTimeOffset end = DateTimeOffset.Now;

        LogResponse(response, (end - start).Milliseconds, builder);

        return response;
    }

    #endregion DelegatingHandler
}