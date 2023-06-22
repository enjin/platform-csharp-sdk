using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for setting the attribute of a collection or token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<AttributeInput>))]
[PublicAPI]
public class AttributeInput : GraphQlParameter<AttributeInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AttributeInput"/> class.
    /// </summary>
    public AttributeInput()
    {
    }

    /// <summary>
    /// Sets the attribute key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>This parameter for chaining.</returns>
    public AttributeInput SetKey(string? key)
    {
        return SetParameter("key", key);
    }

    /// <summary>
    /// Sets the attribute value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>This parameter for chaining.</returns>
    public AttributeInput SetValue(string? value)
    {
        return SetParameter("value", value);
    }
}