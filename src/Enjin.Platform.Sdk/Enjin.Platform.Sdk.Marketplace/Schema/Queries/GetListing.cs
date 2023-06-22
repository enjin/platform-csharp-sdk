using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request for querying a market listing.
/// </summary>
/// <seealso cref="MarketplaceListing"/>
[PublicAPI]
public class GetListing : GraphQlRequest<GetListing, MarketplaceListingFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetListing"/> class.
    /// </summary>
    public GetListing() : base("GetListing", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the internal ID.
    /// </summary>
    /// <param name="id">The internal ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetListing SetId(BigInteger? id)
    {
        return SetVariable("id", CoreTypes.BigInt, id);
    }

    /// <summary>
    /// Sets the listing ID.
    /// </summary>
    /// <param name="listingId">The listing ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetListing SetListingId(string? listingId)
    {
        return SetVariable("listingId", CoreTypes.String, listingId);
    }
}