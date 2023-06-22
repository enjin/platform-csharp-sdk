using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models an edge for an entry in a pagination.
/// </summary>
/// <typeparam name="T">The type within the pagination.</typeparam>
[PublicAPI]
public class Edge<T>
{
    /// <summary>
    /// The item on the current cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("node")]
    public T? Node { get; private set; }

    /// <summary>
    /// The current cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("cursor")]
    public string? Cursor { get; private set; }
}