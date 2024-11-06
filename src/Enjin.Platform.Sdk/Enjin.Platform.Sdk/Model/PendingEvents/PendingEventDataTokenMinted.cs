using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataTokenMinted : PendingEventDataBase
{
    /// <summary>
    /// The amount that issued the mint.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("issuer")]
    public string? Issuer { get; private set; }

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

    /// <summary>
    /// The recipient of the mint.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("recipient")]
    public string? Recipient { get; private set; }

    /// <summary>
    /// The amount that was minted.
    /// </summary>
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger Amount { get; private set; }
}