using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the data for a fixed price listing.
/// </summary>
[PublicAPI]
public class FixedPriceData : ListingData
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }
}