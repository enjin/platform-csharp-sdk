using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying market listings.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="MarketplaceListing"/>
[PublicAPI]
public class GetListings : GraphQlRequest<GetListings, MarketplaceListingConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetListings"/> class.
    /// </summary>
    public GetListings() : base("GetListings", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal IDs.
    /// </summary>
    /// <param name="ids">The internal IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetListings SetIds(params BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the listing IDs.
    /// </summary>
    /// <param name="listingIds">The listing IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetListings SetListingIds(params string[]? listingIds)
    {
        return SetVariable("listingIds", CoreTypes.StringArray, listingIds);
    }

    /// <summary>
    /// Sets the wallet account.
    /// </summary>
    /// <param name="account">The wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public GetListings SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }

    /// <summary>
    /// Sets the collection and token ID of the asset being sold.
    /// </summary>
    /// <param name="makeAssetId">The collection and token ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetListings SetMakeAssetId(MultiTokenIdInput? makeAssetId)
    {
        return SetVariable("makeAssetId", CoreTypes.MultiTokenIdInput, makeAssetId);
    }

    /// <summary>
    /// Sets the collection and token ID of the asset being requested.
    /// </summary>
    /// <param name="takeAssetId">The collection and token ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetListings SetTakeAssetId(MultiTokenIdInput? takeAssetId)
    {
        return SetVariable("takeAssetId", CoreTypes.MultiTokenIdInput, takeAssetId);
    }
}