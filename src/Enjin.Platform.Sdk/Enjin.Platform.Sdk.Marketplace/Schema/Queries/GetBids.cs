using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying market listing bids.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="MarketplaceBid"/>
[PublicAPI]
public class GetBids : GraphQlRequest<GetBids, MarketplaceBidConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBids"/> class.
    /// </summary>
    public GetBids() : base("GetBids", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal IDs.
    /// </summary>
    /// <param name="ids">The internal IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetBids SetIds(params BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the wallet accounts.
    /// </summary>
    /// <param name="accounts">The wallet accounts.</param>
    /// <returns>This request for chaining.</returns>
    public GetBids SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }

    /// <summary>
    /// Sets the listing IDs.
    /// </summary>
    /// <param name="listingIds">The listing IDs.</param>
    /// <returns></returns>
    public GetBids SetListingIds(params string[]? listingIds)
    {
        return SetVariable("listingIds", CoreTypes.StringArray, listingIds);
    }
}