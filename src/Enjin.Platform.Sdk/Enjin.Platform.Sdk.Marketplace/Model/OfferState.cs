using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the data for a listing offer state.
/// </summary>
[PublicAPI]
public class OfferState : ListingState
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }
    
    /// <summary>
    /// The number of counteroffers.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("counterOfferCount")]
    public int? CounterOfferCount { get; private set; }
}