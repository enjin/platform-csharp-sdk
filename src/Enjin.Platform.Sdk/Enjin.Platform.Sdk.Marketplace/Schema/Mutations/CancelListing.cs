using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request to act as a mutation for canceling a listing.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class CancelListing : GraphQlRequest<CancelListing, TransactionFragment>,
                             IHasIdempotencyKey<CancelListing>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelListing"/> class.
    /// </summary>
    public CancelListing() : base("CancelListing", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the listing ID.
    /// </summary>
    /// <param name="listingId">The listing ID.</param>
    /// <returns>This request for chaining.</returns>
    public CancelListing SetListingId(string? listingId)
    {
        return SetVariable("listingId", CoreTypes.String, listingId);
    }
}