using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for classes implementing <see cref="IGraphQlParameter"/>.
/// </summary>
/// <typeparam name="TValue">The parameter type. Must implement <see cref="IGraphQlParameter"/>.</typeparam>
[PublicAPI]
public class GraphQlParameterJsonConverter<TValue> : JsonConverter<TValue>
    where TValue : IGraphQlParameter
{
    /// <summary>
    /// Unsupported conversion.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Always thrown when called.
    /// </exception>
    public override TValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException($"{nameof(IGraphQlParameter)} is not a valid read type");
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, TValue value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        foreach (var variable in value.Parameters)
        {
            if (variable.Value is List<IGraphQlParameter> array)
            {
                writer.WritePropertyName(variable.Key);
                writer.WriteStartArray();
                foreach (var item in array)
                {
                    writer.WriteStartObject();
                    foreach (var parameter in item.Parameters)
                    {
                        writer.WritePropertyName(parameter.Key);
                        if (parameter.Value is BigInteger val)
                            writer.WriteRawValue(val.ToString(CultureInfo.InvariantCulture));
                        else 
                            writer.WriteRawValue(JsonSerializer.Serialize(parameter.Value, options));
                    }

                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }
            else
            {
                writer.WritePropertyName(variable.Key);
                writer.WriteRawValue(JsonSerializer.Serialize(variable.Value, options));
            }
        }

        writer.WriteEndObject();
    }
}