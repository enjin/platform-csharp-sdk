using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for changing the default values of a token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class MutateToken : GraphQlRequest<MutateToken, TransactionFragment>,
                           IHasEncodableTokenId<MutateToken>,
                           IHasIdempotencyKey<MutateToken>,
                           IHasSkipValidation<MutateToken>,
                           IHasSigningAccount<MutateToken>,
                           IHasSimulate<MutateToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MutateToken"/> class.
    /// </summary>
    public MutateToken() : base("MutateToken", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that will be mutated.
    /// </summary>
    /// <param name="collectionId">The ID of the collection.</param>
    /// <returns>This request for chaining.</returns>
    public MutateToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the parameters that will be mutated.
    /// </summary>
    /// <param name="mutation">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public MutateToken SetMutation(TokenMutationInput? mutation)
    {
        return SetVariable("mutation", CoreTypes.TokenMutationInput, mutation);
    }
}