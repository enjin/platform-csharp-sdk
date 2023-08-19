using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A fragment for requesting properties of a <see cref="MarketplaceListing"/> returned by the platform.
/// </summary>
[PublicAPI]
public class MarketplaceListingFragment : GraphQlFragment<MarketplaceListingFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketplaceListingFragment"/> class.
    /// </summary>
    public MarketplaceListingFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its <see cref="MarketplaceListing.Id"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.ListingId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithListingId(bool isIncluded = true)
    {
        return WithField("listingId", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Asset"/> fragment to be used for getting the <see cref="MarketplaceListing.MakeAssetId"/>
    /// property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Asset"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithMakeAssetId(AssetFragment? fragment)
    {
        return WithField("makeAssetId", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Asset"/> fragment to be used for getting the <see cref="MarketplaceListing.TakeAssetId"/>
    /// property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Asset"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithTakeAssetId(AssetFragment? fragment)
    {
        return WithField("takeAssetId", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.Amount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithAmount(bool isIncluded = true)
    {
        return WithField("amount", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.Price"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithPrice(bool isIncluded = true)
    {
        return WithField("price", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.MinTakeValue"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithMinTakeValue(bool isIncluded = true)
    {
        return WithField("minTakeValue", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.FeeSide"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithFeeSide(bool isIncluded = true)
    {
        return WithField("feeSide", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.CreationBlock"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithCreationBlock(bool isIncluded = true)
    {
        return WithField("creationBlock", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.Deposit"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithDeposit(bool isIncluded = true)
    {
        return WithField("deposit", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="MarketplaceListing"/> is to be returned with its
    /// <see cref="MarketplaceListing.Salt"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithSalt(bool isIncluded = true)
    {
        return WithField("salt", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="ListingState"/> fragment to be used for getting the <see cref="MarketplaceListing.State"/>
    /// property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="ListingState"/> fragment.</param>
    /// <typeparam name="TFragment">The specific type of the state fragment.</typeparam>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithState<TFragment>(ListingStateFragment<TFragment>? fragment)
        where TFragment : ListingStateFragment<TFragment>
    {
        return WithField("state", fragment);
    }

    /// <summary>
    /// Sets the <see cref="ListingData"/> fragment to be used for getting the <see cref="MarketplaceListing.Data"/>
    /// property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="ListingData"/> fragment.</param>
    /// <typeparam name="TFragment">The specific type of the data fragment.</typeparam>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithData<TFragment>(ListingDataFragment<TFragment>? fragment)
        where TFragment : ListingDataFragment<TFragment>
    {
        return WithField("data", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="MarketplaceListing.Seller"/>
    /// property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithSeller(WalletFragment? fragment)
    {
        return WithField("seller", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="MarketplaceSale"/>, to be used for getting
    /// the <see cref="MarketplaceListing.Sales"/> property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="MarketplaceSale"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithSales(MarketplaceSaleConnectionFragment? fragment)
    {
        return WithField("sales", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Connection{T}"/> fragment, which uses <see cref="MarketplaceBid"/>, to be used for getting
    /// the <see cref="MarketplaceListing.Bids"/> property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">
    /// The <see cref="Connection{T}"/> fragment, which uses <see cref="MarketplaceBid"/>.
    /// </param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithBids(MarketplaceBidConnectionFragment? fragment)
    {
        return WithField("bids", fragment);
    }

    /// <summary>
    /// Sets the <see cref="MarketplaceState"/> fragment to be used for getting the
    /// <see cref="MarketplaceListing.States"/> property of the <see cref="MarketplaceListing"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="MarketplaceState"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public MarketplaceListingFragment WithStates(MarketplaceStateFragment? fragment)
    {
        return WithField("states", fragment);
    }
}