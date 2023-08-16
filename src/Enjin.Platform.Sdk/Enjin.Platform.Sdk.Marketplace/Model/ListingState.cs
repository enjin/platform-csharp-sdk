using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models the mutable state of a listing.
/// </summary>
/// <seealso cref="AuctionState"/>
/// <seealso cref="FixedPriceState"/>
[JsonConverter(typeof(ListingStateJsonConverter))]
[PublicAPI]
public abstract class ListingState
{
}