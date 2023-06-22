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
public class DestroyCollection : GraphQlRequest<DestroyCollection, TransactionFragment>,
                                 IHasIdempotencyKey<DestroyCollection>,
                                 IHasSkipValidation<DestroyCollection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DestroyCollection"/> class.
    /// </summary>
    public DestroyCollection() : base("DestroyCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public DestroyCollection SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}