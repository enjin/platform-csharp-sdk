using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for minting more of an existing token.
/// </summary>
/// <remarks>
/// This operation only applies to tokens which have a supply cap greater than 1.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class MintToken : GraphQlRequest<MintToken, TransactionFragment>,
                         IHasIdempotencyKey<MintToken>,
                         IHasSkipValidation<MintToken>,
                         IHasSigningAccount<MintToken>,
                         IHasSimulate<MintToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MintToken"/> class.
    /// </summary>
    public MintToken() : base("MintToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the recipient account that will receive the transfer.
    /// </summary>
    /// <param name="recipient">The recipient account.</param>
    /// <returns>This request for chaining.</returns>
    public MintToken SetRecipient(string? recipient)
    {
        return SetVariable("recipient", CoreTypes.String, recipient);
    }

    /// <summary>
    /// Sets the collection ID to mint from.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public MintToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the parameters for minting the token.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public MintToken SetParams(MintTokenParams? parameters)
    {
        return SetVariable("params", CoreTypes.MintTokenParams, parameters);
    }
}