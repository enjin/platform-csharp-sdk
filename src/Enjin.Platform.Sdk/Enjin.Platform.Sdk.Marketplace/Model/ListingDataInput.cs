using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Models a parameter for data for an auction.
/// </summary>
[PublicAPI]
public class ListingDataInput : GraphQlParameter<ListingDataInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListingDataInput"/> class.
    /// </summary>
    public ListingDataInput()
    {
    }

    /// <summary>
    /// Sets the type of listing.
    /// </summary>
    /// <param name="type">The listing type.</param>
    /// <returns>This parameter for chaining.</returns>
    public ListingDataInput SetType(ListingType? type)
    {
        return SetParameter("type", type);
    }

    /// <summary>
    /// Sets the parameters for an auction listing.
    /// </summary>
    /// <param name="auctionParams">The auction params.</param>
    /// <returns>This parameter for chaining.</returns>
    public ListingDataInput SetAuctionParams(AuctionParamsInput? auctionParams)
    {
        return SetParameter("auctionParams", auctionParams);
    }
    
    /// <summary>
    /// Sets the parameters for an offer.
    /// </summary>
    /// <param name="offerParams">The offer params.</param>
    /// <returns>This parameter for chaining.</returns>
    public ListingDataInput SetOfferParams(OfferParamsInput? offerParams)
    {
        return SetParameter("offerParams", offerParams);
    }
}