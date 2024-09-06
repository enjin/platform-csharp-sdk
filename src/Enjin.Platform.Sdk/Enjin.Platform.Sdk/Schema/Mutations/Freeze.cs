using System;
using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for freezing a collection, token, collection account, or token account.
/// </summary>
/// <remarks>
/// Tokens cannot be transferred or burned if they are frozen. Freezing a collection or collection account will freeze
/// all the tokens in it.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class Freeze : GraphQlRequest<Freeze, TransactionFragment>,
                      IHasEncodableTokenId<Freeze>,
                      IHasIdempotencyKey<Freeze>,
                      IHasSkipValidation<Freeze>,
                      IHasSigningAccount<Freeze>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Freeze"/> class.
    /// </summary>
    public Freeze() : base("Freeze", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the type of freezing to do.
    /// </summary>
    /// <param name="freezeType">The freezing type.</param>
    /// <returns>This request for chaining.</returns>
    public Freeze SetFreezeType(FreezeType? freezeType)
    {
        return SetVariable("freezeType", CoreTypes.FreezeType, freezeType);
    }
    
    /// <summary>
    /// Sets the freeze state type.
    /// </summary>
    /// <param name="freezeState">The freeze state type.</param>
    /// <returns>This request for chaining.</returns>
    public Freeze SetFreezeState(FreezeState? freezeState)
    {
        return SetVariable("freezeState", CoreTypes.FreezeState, freezeState);
    }

    /// <summary>
    /// Sets the collection ID to freeze.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public Freeze SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
    
    /// <summary>
    /// Sets the collection account to freeze.
    /// </summary>
    /// <param name="collectionAccount">The collection account.</param>
    /// <returns>This request for chaining.</returns>
    public Freeze SetCollectionAccount(string? collectionAccount)
    {
        return SetVariable("collectionAccount", CoreTypes.String, collectionAccount);
    }

    /// <summary>
    /// Sets the token account to freeze.
    /// </summary>
    /// <param name="tokenAccount">The token account.</param>
    /// <returns>This request for chaining.</returns>
    public Freeze SetTokenAccount(string? tokenAccount)
    {
        return SetVariable("tokenAccount", CoreTypes.String, tokenAccount);
    }
}