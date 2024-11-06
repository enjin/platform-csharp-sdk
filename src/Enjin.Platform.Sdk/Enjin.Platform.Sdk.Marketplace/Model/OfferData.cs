using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the data for an offer listing.
/// </summary>
[PublicAPI]
public class OfferData : ListingData
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }
    
    /// <summary>
    /// The expiration time of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; private set; }
}