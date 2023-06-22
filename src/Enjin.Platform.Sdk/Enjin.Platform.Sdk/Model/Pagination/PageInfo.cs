using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models information for a page of data.
/// </summary>
[PublicAPI]
public class PageInfo
{
    /// <summary>
    /// Determines if the cursor has more pages after the current page.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("hasNextPage")]
    public bool? HasNextPage { get; private set; }

    /// <summary>
    /// Determines if the cursor has more pages before the current page.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("hasPreviousPage")]
    public bool? HasPreviousPage { get; private set; }

    /// <summary>
    /// The previous cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("startCursor")]
    public string? StartCursor { get; private set; }

    /// <summary>
    /// The next cursor.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("endCursor")]
    public string? EndCursor { get; private set; }
}