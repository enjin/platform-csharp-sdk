using System;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A platform HTTP request carrying a GraphQL document for <see cref="PlatformClient"/> to dispatch.
/// </summary>
[PublicAPI]
public sealed class PlatformRequest : IPlatformRequest
{
    private const string GraphQlMediaType = "application/json";

    /// <inheritdoc/>
    public HttpContent Content { get; }

    /// <inheritdoc/>
    public string Path { get; }

    private PlatformRequest(HttpContent content, string path)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
        Path = path ?? throw new ArgumentNullException(nameof(path));
    }

    /// <summary>
    /// Creates a request that will POST the given GraphQL operation to the platform endpoint.
    /// </summary>
    /// <param name="builder">The GraphQL operation built via <see cref="QueryQueryBuilder"/> or <see cref="MutationQueryBuilder"/>.</param>
    /// <param name="path">The relative path of the GraphQL endpoint. Defaults to an empty string, meaning the client's <c>BaseAddress</c> already points at the endpoint.</param>
    /// <returns>A new <see cref="PlatformRequest"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> is <c>null</c>.</exception>
    public static PlatformRequest GraphQl(GraphQlQueryBuilder builder, string path = "")
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        string body = JsonConvert.SerializeObject(new GraphQlRequestBody(builder.Build()));
        StringContent content = new(body, Encoding.UTF8, GraphQlMediaType);

        return new PlatformRequest(content, path);
    }

    /// <summary>
    /// Serializable wire format for a GraphQL HTTP POST body.
    /// </summary>
    private sealed class GraphQlRequestBody
    {
        [JsonProperty("query")]
        public string Query { get; }

        public GraphQlRequestBody(string query)
        {
            Query = query;
        }
    }
}
