using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters that can be used to filter data.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TokenFilterInput>))]
[PublicAPI]
public class TokenFilterInput : GraphQlParameter<TokenFilterInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringFilterInput"/> class.
    /// </summary>
    public TokenFilterInput()
    {
    }
    
    /// <summary>
    /// Sets the tokenIds.
    /// </summary>
    /// <param name="tokenIds">The token IDs.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenFilterInput SetTokenIds(params IntegerRangeString[]? tokenIds)
    {
        return SetParameter("tokenIds", tokenIds);
    }

    /// <summary>
    /// Sets the collection ID of a multi-token.
    /// </summary>
    /// <param name="collectionId">The collection ID.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenFilterInput SetCollectionId(BigInteger? collectionId)
    {
        return SetParameter("collectionId", collectionId);
    }
}