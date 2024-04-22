using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// A request to act as a mutation for placing a sell order.
/// </summary>
/// <see cref="Transaction"/>
[PublicAPI]
public class CreateListing : GraphQlRequest<CreateListing, TransactionFragment>,
                             IHasIdempotencyKey<CreateListing>,
                             IHasSkipValidation<CreateListing>,
                             IHasSigningAccount<CreateListing>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateListing"/> class.
    /// </summary>
    public CreateListing() : base("CreateListing", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the seller account.
    /// </summary>
    /// <param name="account">The seller account.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetAccount(string? account)
    {
        return SetVariable("account", CoreTypes.String, account);
    }

    /// <summary>
    /// Sets the collection and token ID of the asset being sold.
    /// </summary>
    /// <param name="makeAssetId">The collection and token ID.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetMakeAssetId(MultiTokenIdInput? makeAssetId)
    {
        return SetVariable("makeAssetId", CoreTypes.MultiTokenIdInput, makeAssetId);
    }

    /// <summary>
    /// Sets the collection and token ID of the asset being requested.
    /// </summary>
    /// <param name="takeAssetId">The collection and token ID.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetTakeAssetId(MultiTokenIdInput? takeAssetId)
    {
        return SetVariable("takeAssetId", CoreTypes.MultiTokenIdInput, takeAssetId);
    }

    /// <summary>
    /// Sets the number of units being sold.
    /// </summary>
    /// <param name="amount">The number of units.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }

    /// <summary>
    /// Sets the requested price for each unit. If it’s an auction, this is the minimum bid.
    /// </summary>
    /// <param name="price">The requested price.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetPrice(BigInteger? price)
    {
        return SetVariable("price", CoreTypes.BigInt, price);
    }

    /// <summary>
    /// Sets the salt for the listing.
    /// </summary>
    /// <param name="salt">The salt.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetSalt(string? salt)
    {
        return SetVariable("salt", CoreTypes.String, salt);
    }

    /// <summary>
    /// Sets the data for an auction.
    /// </summary>
    /// <param name="auctionData">The auction data.</param>
    /// <returns>This request for chaining.</returns>
    public CreateListing SetAuctionData(AuctionDataInputType? auctionData)
    {
        return SetVariable("auctionData", MarketplaceTypes.AuctionDataInputType, auctionData);
    }
}