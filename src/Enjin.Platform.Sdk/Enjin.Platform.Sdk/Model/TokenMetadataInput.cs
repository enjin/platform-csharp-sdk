using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting the metadata on a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<TokenMetadataInput>))]
[PublicAPI]
public class TokenMetadataInput : GraphQlParameter<TokenMetadataInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenMetadataInput"/> class.
    /// </summary>
    public TokenMetadataInput()
    {
    }

    /// <summary>
    /// Sets the token name.
    /// </summary>
    /// <param name="name">The token name.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMetadataInput SetName(string? name)
    {
        return SetParameter("name", name);
    }
    
    /// <summary>
    /// Sets the token symbol.
    /// </summary>
    /// <param name="symbol">The symbol name.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMetadataInput SetSymbol(string? symbol)
    {
        return SetParameter("symbol", symbol);
    }
    
    /// <summary>
    /// Sets the token decimal count.
    /// </summary>
    /// <param name="decimalCount">The decimal count.</param>
    /// <returns>This parameter for chaining.</returns>
    public TokenMetadataInput SetDecimalCount(int? decimalCount)
    {
        return SetParameter("decimalCount", decimalCount);
    }
}