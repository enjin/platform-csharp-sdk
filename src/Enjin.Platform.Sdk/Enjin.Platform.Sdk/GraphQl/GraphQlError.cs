using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an error in a GraphQL response.
/// </summary>
[PublicAPI]
public class GraphQlError
{
    /// <summary>
    /// The message for this error.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("message")]
    public string? Message { get; private set; }

    /// <summary>
    /// An extension containing other information regarding this error.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("extensions")]
    public JsonElement? Extensions { get; private set; }

    /// <summary>
    /// The locations in the request where this error occurred.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("locations")]
    public IEnumerable<GraphQlErrorLocation>? Locations { get; private set; }

    /// <summary>
    /// The path in the request where this error occurred.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("path")]
    public IEnumerable<string>? Path { get; private set; }
}