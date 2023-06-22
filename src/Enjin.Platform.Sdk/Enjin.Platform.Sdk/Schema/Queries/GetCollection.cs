using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a collection by its collection ID.
/// </summary>
/// <seealso cref="Collection"/>
[PublicAPI]
public class GetCollection : GraphQlRequest<GetCollection, CollectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCollection"/> class.
    /// </summary>
    public GetCollection() : base("GetCollection", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the on-chain collection ID to get.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetCollection SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}