using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request to act as a mutation for placing a bid on a listing.
/// </summary>
/// <remarks>
/// The listing must be an auction, and it must be currently active.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class PlaceBid : GraphQlRequest<PlaceBid, TransactionFragment>,
                        IHasIdempotencyKey<PlaceBid>,
                        IHasSkipValidation<PlaceBid>,
                        IHasSimulate<PlaceBid>,
                        IHasSigningAccount<PlaceBid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PlaceBid"/> class.
    /// </summary>
    public PlaceBid() : base("PlaceBid", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the listing ID.
    /// </summary>
    /// <param name="listingId">The listing ID.</param>
    /// <returns>This request for chaining.</returns>
    public PlaceBid SetListingId(string? listingId)
    {
        return SetVariable("listingId", CoreTypes.String, listingId);
    }

    /// <summary>
    /// Sets the bid amount.
    /// </summary>
    /// <param name="price">The amount.</param>
    /// <returns>This request for chaining.</returns>
    public PlaceBid SetPrice(BigInteger? price)
    {
        return SetVariable("price", CoreTypes.BigInt, price);
    }
}