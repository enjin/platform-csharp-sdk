using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an edge for an entry in a pagination.
/// </summary>
/// <typeparam name="TModel">The type model within the pagination.</typeparam>
[PublicAPI]
public class Edge<TModel>
{
    /// <summary>
    /// The item on the current cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("node")]
    public TModel? Node { get; private set; }

    /// <summary>
    /// The current cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("cursor")]
    public string? Cursor { get; private set; }
}