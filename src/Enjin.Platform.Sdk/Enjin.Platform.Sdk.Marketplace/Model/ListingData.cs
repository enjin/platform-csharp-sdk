using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the specialized data for a listing.
/// </summary>
/// <seealso cref="AuctionData"/>
/// <seealso cref="FixedPriceData"/>
[JsonConverter(typeof(ListingDataJsonConverter))]
[PublicAPI]
public abstract class ListingData
{
}