using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="IntegerRangeString"/> type allowing for the conversion of the
/// <c>IntegerRangeString</c> type used in the platform's GraphQL API.
/// </summary>
[UsedImplicitly]
public class IntegerRangeStringJsonConverter : JsonConverter<IntegerRangeString>
{
    /// <summary>
    /// Unsupported conversion.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Always thrown when called.
    /// </exception>
    public override IntegerRangeString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException($"{nameof(IntegerRangeString)} is not a valid read type");
    }

    /// <inheritdoc/>
    /// <remarks>
    /// When used as a parameter, the <c>IntegerRangeString</c> type on the platform is to be passed as a string and as such
    /// this converter writes it as a JSON string.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, IntegerRangeString value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}