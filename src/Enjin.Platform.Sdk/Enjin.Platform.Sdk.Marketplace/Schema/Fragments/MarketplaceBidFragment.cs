using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="MarketplaceBid"/> returned by the platform.
/// </summary>
[PublicAPI]
public class MarketplaceBidFragment : GraphQlFragment<MarketplaceBidFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketplaceBidFragment"/> class.
    /// </summary>
    public MarketplaceBidFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceBid"/> is to be returned with its <see cref="MarketplaceBid.Id"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceBidFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceBid"/> is to be returned with its <see cref="MarketplaceBid.Price"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceBidFragment WithPrice(bool isIncluded = true)
    {
        return WithField("price", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceBid"/> is to be returned with its <see cref="MarketplaceBid.Height"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceBidFragment WithHeight(bool isIncluded = true)
    {
        return WithField("height", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="MarketplaceBid.Bidder"/> property
    /// of the <see cref="MarketplaceBid"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceBidFragment WithBidder(WalletFragment? fragment)
    {
        return WithField("bidder", fragment);
    }

    /// <summary>
    /// Sets the <see cref="MarketplaceListing"/> fragment to be used for getting the
    /// <see cref="MarketplaceBid.Listing"/> property of the <see cref="MarketplaceBid"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="MarketplaceListing"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceBidFragment WithListing(MarketplaceListingFragment? fragment)
    {
        return WithField("listing", fragment);
    }
}