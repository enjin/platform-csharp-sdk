using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation to thaw a previously frozen collection or token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class Thaw : GraphQlRequest<Thaw, TransactionFragment>,
                    IHasEncodableTokenId<Thaw>,
                    IHasIdempotencyKey<Thaw>,
                    IHasSkipValidation<Thaw>,
                    IHasSigningAccount<Thaw>,
                    IHasSimulate<Thaw>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Thaw"/> class.
    /// </summary>
    public Thaw() : base("Thaw", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the type of thawing to do.
    /// </summary>
    /// <param name="freezeType">The thawing type.</param>
    /// <returns>This request for chaining.</returns>
    public Thaw SetFreezeType(FreezeType? freezeType)
    {
        return SetVariable("freezeType", CoreTypes.FreezeType, freezeType);
    }

    /// <summary>
    /// Sets the collection ID to thaw.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public Thaw SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the collection account to thaw.
    /// </summary>
    /// <param name="collectionAccount">The collection account.</param>
    /// <returns>This request for chaining.</returns>
    public Thaw SetCollectionAccount(string? collectionAccount)
    {
        return SetVariable("collectionAccount", CoreTypes.String, collectionAccount);
    }

    /// <summary>
    /// Sets the token account to thaw.
    /// </summary>
    /// <param name="tokenAccount">The token account.</param>
    /// <returns>This request for chaining.</returns>
    public Thaw SetTokenAccount(string? tokenAccount)
    {
        return SetVariable("tokenAccount", CoreTypes.String, tokenAccount);
    }
}