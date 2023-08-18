using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a pagination from the platform.
/// </summary>
/// <typeparam name="TModel">The type model within the pagination.</typeparam>
[PublicAPI]
public class Connection<TModel>
{
    /// <summary>
    /// The edges in this connection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("edges")]
    public IEnumerable<Edge<TModel>>? Edges { get; private set; }

    /// <summary>
    /// The page information for this connection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("pageInfo")]
    public PageInfo? PageInfo { get; private set; }

    /// <summary>
    /// The total count of items in this connection.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("totalCount")]
    public int? TotalCount { get; private set; }
}