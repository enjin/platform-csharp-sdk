using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="MarketplaceSale"/> returned by the platform.
/// </summary>
[PublicAPI]
public class MarketplaceSaleFragment : GraphQlFragment<MarketplaceSaleFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketplaceSaleFragment"/> class.
    /// </summary>
    public MarketplaceSaleFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceSale"/> is to be returned with its <see cref="MarketplaceSale.Id"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceSaleFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceSale"/> is to be returned with its <see cref="MarketplaceSale.Price"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceSaleFragment WithPrice(bool isIncluded = true)
    {
        return WithField("price", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceSale"/> is to be returned with its <see cref="MarketplaceSale.Amount"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceSaleFragment WithAmount(bool isIncluded = true)
    {
        return WithField("amount", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="MarketplaceSale.Bidder"/> property
    /// of the <see cref="MarketplaceSale"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceSaleFragment WithBidder(WalletFragment? fragment)
    {
        return WithField("bidder", fragment);
    }

    /// <summary>
    /// Sets the <see cref="MarketplaceListing"/> fragment to be used for getting the
    /// <see cref="MarketplaceSale.Listing"/> property of the <see cref="MarketplaceSale"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="MarketplaceListing"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceSaleFragment WithListing(MarketplaceListingFragment? fragment)
    {
        return WithField("listing", fragment);
    }
}