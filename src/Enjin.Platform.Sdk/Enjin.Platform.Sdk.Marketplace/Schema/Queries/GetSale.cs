using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying a market listing sale.
/// </summary>
/// <seealso cref="MarketplaceSale"/>
[PublicAPI]
public class GetSale : GraphQlRequest<GetSale, MarketplaceSaleFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSale"/> class.
    /// </summary>
    public GetSale() : base("GetSale", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal ID.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetSale SetId(BigInteger? id)
    {
        return SetVariable("id", CoreTypes.BigInt, id);
    }
}