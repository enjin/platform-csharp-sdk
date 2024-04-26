using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataTokenCreated : PendingEventDataBase
{
    /// <summary>
    /// The wallet that created this token.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public string Wallet { get; private set; }

    /// <summary>
    /// The token ID of this asset.
    /// </summary>
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("tokenId")]
    public BigInteger TokenId { get; private set; }
    
    /// <summary>
    /// The collection ID of this asset.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("collectionId")]
    public BigInteger? CollectionId { get; private set; }
}