using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the state of an auction listing.
/// </summary>
[PublicAPI]
public class AuctionState : ListingState
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }

    /// <summary>
    /// The highest bid for the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("highestBid")]
    public MarketplaceBid? HighestBid { get; private set; }
}