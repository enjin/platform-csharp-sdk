using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request to act as a mutation for finalizing an auction.
/// </summary>
/// <remarks>
/// This will end the auction and transfer funds. The request will fail if the auction is not over.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class FinalizeAuction : GraphQlRequest<FinalizeAuction, TransactionFragment>,
                               IHasIdempotencyKey<FinalizeAuction>,
                               IHasSkipValidation<FinalizeAuction>,
                               IHasSigningAccount<FinalizeAuction>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FinalizeAuction"/> class.
    /// </summary>
    public FinalizeAuction() : base("FinalizeAuction", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the listing ID.
    /// </summary>
    /// <param name="listingId">The listing ID.</param>
    /// <returns>This request for chaining.</returns>
    public FinalizeAuction SetListingId(string? listingId)
    {
        return SetVariable("listingId", CoreTypes.String, listingId);
    }
}