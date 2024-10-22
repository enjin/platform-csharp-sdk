using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the specialized data for a listing.
/// </summary>
/// <seealso cref="AuctionData"/>
/// <seealso cref="FixedPriceData"/>
/// <seealso cref="OfferData"/>
[JsonConverter(typeof(ListingDataJsonConverter))]
[PublicAPI]
public abstract class ListingData
{
}