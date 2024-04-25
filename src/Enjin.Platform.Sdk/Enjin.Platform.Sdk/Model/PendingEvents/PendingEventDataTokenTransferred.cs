using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.PendingEvents;

/// <summary>
/// Models event data that has been broadcasted, but not yet acknowledged.
/// </summary>
[PublicAPI]
public class PendingEventDataTokenTransferred : PendingEventDataBase
{
    /// <summary>
    /// The account that this token was transferred from.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("from")]
    public string From { get; private set; }

    /// <summary>
    /// The amount that was transferred.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("amount")]
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    public BigInteger Amount { get; private set; }
    
    /// <summary>
    /// The token ID of this asset.
    /// </summary>
    [JsonConverter(typeof(BigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("tokenId")]
    public BigInteger TokenId { get; private set; }

    /// <summary>
    /// The recipient of this token transfer.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("recipient")]
    public string Recipient { get; private set; }

    /// <summary>
    /// The collection ID of this asset.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("collectionId")]
    public BigInteger? CollectionId { get; private set; }
}