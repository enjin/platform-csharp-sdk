using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for creating a new on-chain collection.
/// </summary>
/// <remarks>
/// The new collection ID will be returned in the transaction events after being finalized on-chain.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class CreateCollection : GraphQlRequest<CreateCollection, TransactionFragment>,
                                IHasIdempotencyKey<CreateCollection>,
                                IHasSkipValidation<CreateCollection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCollection"/> class.
    /// </summary>
    public CreateCollection() : base("CreateCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the mint policy for tokens in this collection.
    /// </summary>
    /// <param name="mintPolicy">The mint policy.</param>
    /// <returns>This request for chaining.</returns>
    public CreateCollection SetMintPolicy(MintPolicy? mintPolicy)
    {
        return SetVariable("mintPolicy", CoreTypes.MintPolicy, mintPolicy);
    }

    /// <summary>
    /// Sets the market policy for the collection.
    /// </summary>
    /// <param name="marketPolicy">The market policy.</param>
    /// <returns>This request for chaining.</returns>
    public CreateCollection SetMarketPolicy(MarketPolicy? marketPolicy)
    {
        return SetVariable("marketPolicy", CoreTypes.MarketPolicy, marketPolicy);
    }

    /// <summary>
    /// Sets the explicit royalty currencies for tokens in the collection.
    /// </summary>
    /// <param name="explicitRoyaltyCurrencies">The royalty currencies.</param>
    /// <returns>This request for chaining.</returns>
    public CreateCollection SetExplicitRoyaltyCurrencies(params MultiTokenIdInput[]? explicitRoyaltyCurrencies)
    {
        return SetVariable("explicitRoyaltyCurrencies", CoreTypes.MultiTokenIdInputArray, explicitRoyaltyCurrencies);
    }

    /// <summary>
    /// Sets the initial attributes for the collection.
    /// </summary>
    /// <param name="attributes">The attributes.</param>
    /// <returns>This request for chaining.</returns>
    public CreateCollection SetAttributes(params AttributeInput[]? attributes)
    {
        return SetVariable("attributes", CoreTypes.AttributeInputArray, attributes);
    }
}