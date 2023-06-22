using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for deleting a collection and get its reserved value back.
/// </summary>
/// <remarks>
/// A collection can only be destroyed after all tokens have been burned.
/// </remarks>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class Burn : GraphQlRequest<Burn, TransactionFragment>,
                    IHasIdempotencyKey<Burn>,
                    IHasSkipValidation<Burn>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Burn"/> class.
    /// </summary>
    public Burn() : base("Burn", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public Burn SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the parameters required to burn a token.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public Burn SetParams(BurnParamsInput? parameters)
    {
        return SetVariable("params", CoreTypes.BurnParamsInput, parameters);
    }
}