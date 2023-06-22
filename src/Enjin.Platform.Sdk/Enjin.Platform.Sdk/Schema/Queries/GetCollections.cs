using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying an array of collections optionally filtered by collection IDs.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Collection"/>
[PublicAPI]
public class GetCollections : GraphQlRequest<GetCollections, CollectionConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCollections"/> class.
    /// </summary>
    public GetCollections() : base("GetCollections", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the on-chain collection IDs to filter to.
    /// </summary>
    /// <param name="collectionIds">The collection IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetCollections SetCollectionIds(params BigInteger[]? collectionIds)
    {
        return SetVariable("collectionIds", CoreTypes.BigIntArray, collectionIds);
    }
}