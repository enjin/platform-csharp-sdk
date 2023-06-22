using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the state of a marketplace listing.
/// </summary>
[PublicAPI]
public class MarketplaceState
{
    /// <summary>
    /// The internal ID for this state.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The mutable state of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("state")]
    public ListingStateEnum? State { get; private set; }

    /// <summary>
    /// The block height.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("height")]
    public int? Height { get; private set; }

    /// <summary>
    /// The marketplace listing detail.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("listing")]
    public MarketplaceListing? Listing { get; private set; }
}