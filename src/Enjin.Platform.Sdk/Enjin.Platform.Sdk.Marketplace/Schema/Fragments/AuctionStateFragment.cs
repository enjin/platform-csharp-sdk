using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of an <see cref="AuctionState"/> returned by the platform.
/// </summary>
[PublicAPI]
public class AuctionStateFragment : ListingStateFragment<AuctionStateFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuctionStateFragment"/> class.
    /// </summary>
    public AuctionStateFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.ListingId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    /// <remarks>
    /// This field ought to be requested when using this fragment type for a
    /// <see cref="ListingStateFragment{TFragment}"/> or else the <see cref="ListingStateJsonConverter"/> may not be
    /// able to determine the type.
    /// </remarks>
    public AuctionStateFragment WithType(bool isIncluded = true)
    {
        return WithField("type", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="MarketplaceBid"/> fragment to be used for getting the <see cref="AuctionState.HighestBid"/>
    /// property of the <see cref="AuctionState"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="MarketplaceBid"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public AuctionStateFragment WithHighestBid(MarketplaceBidFragment? fragment)
    {
        return WithField("highestBid", fragment);
    }
}