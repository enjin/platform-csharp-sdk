using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying an array of tokens from a collection, optionally filtered by token IDs.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Token"/>
[PublicAPI]
public class GetTokens : GraphQlRequest<GetTokens, TokenConnectionFragment>,
                         IHasEncodableTokenIdArray<GetTokens>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTokens"/> class.
    /// </summary>
    public GetTokens() : base("GetTokens", GraphQlRequestType.Query)
    {
    }
    
    /// <summary>
    /// Sets the ID of the collection to return tokens from.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetTokens SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}