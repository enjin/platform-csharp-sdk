using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for removing an attribute from the specified collection.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RemoveCollectionAttribute : GraphQlRequest<RemoveCollectionAttribute, TransactionFragment>,
                                         IHasIdempotencyKey<RemoveCollectionAttribute>,
                                         IHasSkipValidation<RemoveCollectionAttribute>,
                                         IHasSigningAccount<RemoveCollectionAttribute>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveCollectionAttribute"/> class.
    /// </summary>
    public RemoveCollectionAttribute() : base("RemoveCollectionAttribute", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveCollectionAttribute SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the attribute key.
    /// </summary>
    /// <param name="key">The attribute key.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveCollectionAttribute SetKey(string? key)
    {
        return SetVariable("key", CoreTypes.String, key);
    }
}