using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for changing the default values of a collection.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class MutateCollection : GraphQlRequest<MutateCollection, TransactionFragment>,
                                IHasIdempotencyKey<MutateCollection>,
                                IHasSkipValidation<MutateCollection>,
                                IHasSigningAccount<MutateCollection>,
                                IHasSimulate<MutateCollection>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MutateCollection"/> class.
    /// </summary>
    public MutateCollection() : base("MutateCollection", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that will be mutated.
    /// </summary>
    /// <param name="collectionId">The ID of the collection.</param>
    /// <returns>This request for chaining.</returns>
    public MutateCollection SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the parameters that will be mutated.
    /// </summary>
    /// <param name="mutation">The parameters.</param>
    /// <returns>This request for chaining.</returns>
    public MutateCollection SetMutation(CollectionMutationInput? mutation)
    {
        return SetVariable("mutation", CoreTypes.CollectionMutationInput, mutation);
    }
}