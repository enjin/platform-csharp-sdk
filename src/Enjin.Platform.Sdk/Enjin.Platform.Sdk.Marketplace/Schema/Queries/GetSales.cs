using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying market listing sales.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="MarketplaceSale"/>
[PublicAPI]
public class GetSales : GraphQlRequest<GetSales, MarketplaceSaleConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSales"/> class.
    /// </summary>
    public GetSales() : base("GetSales", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal IDs.
    /// </summary>
    /// <param name="ids">The internal IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetSales SetIds(params BigInteger[]? ids)
    {
        return SetVariable("ids", CoreTypes.BigIntArray, ids);
    }

    /// <summary>
    /// Sets the wallet accounts.
    /// </summary>
    /// <param name="accounts">Te wallet accounts.</param>
    /// <returns>This request for chaining.</returns>
    public GetSales SetAccounts(params string[]? accounts)
    {
        return SetVariable("accounts", CoreTypes.StringArray, accounts);
    }

    /// <summary>
    /// Sets the listing IDs.
    /// </summary>
    /// <param name="listingIds">The listing IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetSales SetListingIds(params string[]? listingIds)
    {
        return SetVariable("listingIds", CoreTypes.StringArray, listingIds);
    }
}