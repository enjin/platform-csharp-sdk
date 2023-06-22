using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models an auction bid.
/// </summary>
[PublicAPI]
public class MarketplaceBid
{
    /// <summary>
    /// The internal ID of this bid.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The minimum bid price for each unit.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("price")]
    public BigInteger? Price { get; private set; }

    /// <summary>
    /// The block height.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("height")]
    public int? Height { get; private set; }

    /// <summary>
    /// The account that placed the bid.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("bidder")]
    public Wallet? Bidder { get; private set; }

    /// <summary>
    /// The marketplace listing detail.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("listing")]
    public MarketplaceListing? Listing { get; private set; }
}