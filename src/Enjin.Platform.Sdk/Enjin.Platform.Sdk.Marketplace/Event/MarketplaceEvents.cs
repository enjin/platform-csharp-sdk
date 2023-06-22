using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Static class which contains members representing the name of each marketplace based event on the platform.
/// </summary>
[PublicAPI]
public static class MarketplaceEvents
{
    /// <summary>
    /// The name of the event for when an auction has been finalized.
    /// </summary>
    public const string AuctionFinalized = "platform:auction-finalized";

    /// <summary>
    /// The name of the event for when a bid has been placed.
    /// </summary>
    public const string BidPlaced = "platform:bid-placed";

    /// <summary>
    /// The name of the event for when a listing has been cancelled.
    /// </summary>
    public const string ListingCancelled = "platform:listing-cancelled";

    /// <summary>
    /// The name of the event for when a listing has been created.
    /// </summary>
    public const string ListingCreated = "platform:listing-created";

    /// <summary>
    /// The name of the event for when a listing has been filled.
    /// </summary>
    public const string ListingFilled = "platform:listing-filled";
}