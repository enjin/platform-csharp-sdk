using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying a market listing bid.
/// </summary>
/// <seealso cref="MarketplaceBid"/>
[PublicAPI]
public class GetBid : GraphQlRequest<GetBid, MarketplaceBidFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBid"/> class.
    /// </summary>
    public GetBid() : base("GetBid", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal ID.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetBid SetId(BigInteger? id)
    {
        return SetVariable("id", CoreTypes.BigInt, id);
    }
}