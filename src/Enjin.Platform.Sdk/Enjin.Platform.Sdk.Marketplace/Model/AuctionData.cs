using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the data for an auction listing.
/// </summary>
[PublicAPI]
public class AuctionData : ListingData
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }

    /// <summary>
    /// The block number the auction starts at.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("startBlock")]
    public int? StartBlock { get; private set; }

    /// <summary>
    /// The block number the auction ends at.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("endBlock")]
    public int? EndBlock { get; private set; }
}