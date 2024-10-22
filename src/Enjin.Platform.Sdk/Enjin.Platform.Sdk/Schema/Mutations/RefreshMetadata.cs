using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for changing the default values of a token.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RefreshMetadata : GraphQlRequest<RefreshMetadata, TransactionFragment>,
                           IHasEncodableTokenId<RefreshMetadata>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RefreshMetadata"/> class.
    /// </summary>
    public RefreshMetadata() : base("RefreshMetadata", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the ID of the collection that will be refreshed.
    /// </summary>
    /// <param name="collectionId">The ID of the collection.</param>
    /// <returns>This request for chaining.</returns>
    public RefreshMetadata SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}