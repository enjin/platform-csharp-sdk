using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the state of a fixed price listing.
/// </summary>
[PublicAPI]
public class FixedPriceState : ListingState
{
    /// <summary>
    /// The type of the listing.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    public ListingType? Type { get; private set; }

    /// <summary>
    /// The amount of the listing that has been filled.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("type")]
    public BigInteger? AmountFilled { get; private set; }
}