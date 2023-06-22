using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a token asset.
/// </summary>
[PublicAPI]
public class Asset
{
    /// <summary>
    /// The collection ID of this asset.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("collectionId")]
    public BigInteger? CollectionId { get; private set; }

    /// <summary>
    /// The token ID of this asset.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("tokenId")]
    public BigInteger? TokenId { get; private set; }
}