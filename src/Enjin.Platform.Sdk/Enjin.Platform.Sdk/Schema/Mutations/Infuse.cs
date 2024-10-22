using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to Infuse a token with ENJ. This will increase the token's value.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class Infuse : GraphQlRequest<Infuse, TransactionFragment>,
                      IHasEncodableTokenId<Infuse>,
                      IHasIdempotencyKey<Infuse>,
                      IHasSkipValidation<Infuse>,
                      IHasSigningAccount<Infuse>,
                      IHasSimulate<Infuse>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Infuse"/> class.
    /// </summary>
    public Infuse() : base("Infuse", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID that contains the token.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public Infuse SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
    
    /// <summary>
    /// Sets the collection account to freeze.
    /// </summary>
    /// <param name="amount">The collection account.</param>
    /// <returns>This request for chaining.</returns>
    public Infuse SetAmount(BigInteger? amount)
    {
        return SetVariable("amount", CoreTypes.BigInt, amount);
    }
}