using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Represents the type of a listing.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum ListingType
{
    /// <summary>
    /// Indicates the listing is of type <c>FIXED_PRICE</c>.
    /// </summary>
    [EnumMember(Value = "FIXED_PRICE")]
    FixedPrice,

    /// <summary>
    /// Indicates the listing is of type <c>AUCTION</c>.
    /// </summary>
    [EnumMember(Value = "AUCTION")]
    Auction,
    
    /// <summary>
    /// Indicates the listing is of type <c>OFFER</c>.
    /// </summary>
    [EnumMember(Value = "OFFER")]
    Offer,
}