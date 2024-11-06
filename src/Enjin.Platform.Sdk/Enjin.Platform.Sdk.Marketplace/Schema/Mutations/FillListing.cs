using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request to act as a mutation for filling a fixed price listing.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class FillListing : GraphQlRequest<FillListing, TransactionFragment>,
                           IHasIdempotencyKey<FillListing>,
                           IHasSkipValidation<FillListing>,
                           IHasSimulate<FillListing>,
                           IHasSigningAccount<FillListing>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FillListing"/> class.
    /// </summary>
    public FillListing() : base("FillListing", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the listing ID.
    /// </summary>
    /// <param name="listingId">The listing ID.</param>
    /// <returns>This request for chaining.</returns>
    public FillListing SetListing(string? listingId)
    {
        return SetVariable("listingId", CoreTypes.String, listingId);
    }

    /// <summary>
    /// Sets the number of units being sold.
    /// </summary>
    /// <param name="amount">The number of units.</param>
    /// <returns>This request for chaining.</returns>
    public FillListing SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }
}