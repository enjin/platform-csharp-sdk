using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting the metadata on a token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MetadataInput>))]
[PublicAPI]
public class MetadataInput : GraphQlParameter<MetadataInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetadataInput"/> class.
    /// </summary>
    public MetadataInput()
    {
    }

    /// <summary>
    /// Sets the token name.
    /// </summary>
    /// <param name="name">The token name.</param>
    /// <returns>This parameter for chaining.</returns>
    public MetadataInput SetName(string? name)
    {
        return SetParameter("name", name);
    }
    
    /// <summary>
    /// Sets the token symbol.
    /// </summary>
    /// <param name="symbol">The symbol name.</param>
    /// <returns>This parameter for chaining.</returns>
    public MetadataInput SetSymbol(string? symbol)
    {
        return SetParameter("symbol", symbol);
    }
    
    /// <summary>
    /// Sets the token decimal count.
    /// </summary>
    /// <param name="decimalCount">The decimal count.</param>
    /// <returns>This parameter for chaining.</returns>
    public MetadataInput SetDecimalCount(int? decimalCount)
    {
        return SetParameter("decimalCount", decimalCount);
    }
}