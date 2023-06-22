using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="MarketplaceState"/> returned by the platform.
/// </summary>
[PublicAPI]
public class MarketplaceStateFragment : GraphQlFragment<MarketplaceStateFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketplaceStateFragment"/> class.
    /// </summary>
    public MarketplaceStateFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceState"/> is to be returned with its <see cref="MarketplaceState.Id"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceStateFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceState"/> is to be returned with its <see cref="MarketplaceState.State"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceStateFragment WithState(bool isIncluded = true)
    {
        return WithField("state", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceState"/> is to be returned with its <see cref="MarketplaceState.Height"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceStateFragment WithHeight(bool isIncluded = true)
    {
        return WithField("height", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="MarketplaceListing"/> fragment to be used for getting the
    /// <see cref="MarketplaceState.Listing"/> property of the <see cref="MarketplaceState"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="MarketplaceListing"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceStateFragment WithListing(MarketplaceListingFragment? fragment)
    {
        return WithField("listing", fragment);
    }
}