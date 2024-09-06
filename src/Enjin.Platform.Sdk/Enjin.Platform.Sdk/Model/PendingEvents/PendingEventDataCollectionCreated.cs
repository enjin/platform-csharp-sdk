using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataCollectionCreated : PendingEventDataBase
{
    /// <summary>
    /// The address this was sent to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("owner")]
    public string? Owner { get; private set; }
    
    /// <summary>
    /// The collection ID of this asset.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("collectionId")]
    public BigInteger? CollectionId { get; private set; }
}