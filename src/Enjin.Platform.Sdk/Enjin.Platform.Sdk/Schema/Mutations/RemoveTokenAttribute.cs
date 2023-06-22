using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for removing an attribute from the specified token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RemoveTokenAttribute : GraphQlRequest<RemoveTokenAttribute, TransactionFragment>,
                                    IHasEncodableTokenId<RemoveTokenAttribute>,
                                    IHasIdempotencyKey<RemoveTokenAttribute>,
                                    IHasSkipValidation<RemoveTokenAttribute>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveTokenAttribute"/> class.
    /// </summary>
    public RemoveTokenAttribute() : base("RemoveTokenAttribute", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveTokenAttribute SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }

    /// <summary>
    /// Sets the attribute key.
    /// </summary>
    /// <param name="key">The attribute key.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveTokenAttribute SetKey(string? key)
    {
        return SetVariable("key", CoreTypes.String, key);
    }
}