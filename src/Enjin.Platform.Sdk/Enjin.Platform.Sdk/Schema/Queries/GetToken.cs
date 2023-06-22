using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a token from a collection using its token ID.
/// </summary>
/// <seealso cref="Token"/>
[PublicAPI]
public class GetToken : GraphQlRequest<GetToken, TokenFragment>,
                        IHasEncodableTokenId<GetToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetToken"/> class.
    /// </summary>
    public GetToken() : base("GetToken", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the token collection ID.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetToken SetCollectionId(BigInteger? collectionId)
    {
        return SetVariable("collectionId", CoreTypes.BigInt, collectionId);
    }
}