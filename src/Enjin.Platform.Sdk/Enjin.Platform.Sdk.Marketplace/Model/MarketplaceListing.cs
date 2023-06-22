using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the details of a marketplace listing.
/// </summary>
[PublicAPI]
public class MarketplaceListing
{
    /// <summary>
    /// The internal ID of this listing.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The ID of this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("listingId")]
    public string? ListingId { get; private set; }

    /// <summary>
    /// The collection and token ID of the asset being sold.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("makeAssetId")]
    public Asset? MakeAssetId { get; private set; }

    /// <summary>
    /// The collection and token ID of the asset being requested.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("takeAssetId")]
    public Asset? TakeAssetId { get; private set; }

    /// <summary>
    /// The number of units being sold.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("amount")]
    public BigInteger? Amount { get; private set; }

    /// <summary>
    /// The requested price for each unit. If this listing is an auction, then this value is the minimum bid.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("price")]
    public BigInteger? Price { get; private set; }

    /// <summary>
    /// The minimum value of the take asset received for the sale to be a success.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("minTakeValue")]
    public BigInteger? MinTakeValue { get; private set; }

    /// <summary>
    /// The side that is considered money and is used to pay fees for this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("feeSide")]
    public FeeSide? FeeSide { get; private set; }

    /// <summary>
    /// The block number this listing was created on.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("creationBlock")]
    public int? CreationBlock { get; private set; }

    /// <summary>
    /// The deposit that was reserved for this listing.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("deposit")]
    public BigInteger? Deposit { get; private set; }

    /// <summary>
    /// The salt that may be used to differentiate this listing from others.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("salt")]
    public string? Salt { get; private set; }

    /// <summary>
    /// The mutable state for this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("state")]
    public ListingState? State { get; private set; }

    /// <summary>
    /// The specialized data for this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("data")]
    public ListingData? Data { get; private set; }

    /// <summary>
    /// The account making the sale for this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("seller")]
    public Wallet? Seller { get; private set; }

    /// <summary>
    /// The sales of this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("sales")]
    public Connection<MarketplaceSale>? Sales { get; private set; }

    /// <summary>
    /// The auction bids of this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("bids")]
    public Connection<MarketplaceBid>? Bids { get; private set; }

    /// <summary>
    /// The state of this listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("states")]
    public IEnumerable<MarketplaceState>? States { get; private set; }
}