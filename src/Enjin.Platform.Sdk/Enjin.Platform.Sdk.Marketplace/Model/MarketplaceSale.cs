using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a listing sale.
/// </summary>
[PublicAPI]
public class MarketplaceSale
{
    /// <summary>
    /// The internal ID for this sale.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The price each unit was sold at.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("price")]
    public BigInteger? Price { get; private set; }

    /// <summary>
    /// The number of units sold.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; private set; }

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