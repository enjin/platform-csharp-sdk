using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="IntegerRange"/> type allowing for the conversion of the
/// <c>IntegerRange</c> type used in the platform's GraphQL API.
/// </summary>
[UsedImplicitly]
public class IntegerRangeJsonConverter : JsonConverter<IntegerRange>
{
    /// <summary>
    /// Unsupported conversion.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Always thrown when called.
    /// </exception>
    public override IntegerRange Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException($"{nameof(IntegerRange)} is not a valid read type");
    }

    /// <inheritdoc/>
    /// <remarks>
    /// When used as a parameter, the <c>IntegerRange</c> type on the platform is to be passed as a string and as such
    /// this converter writes it as a JSON string.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, IntegerRange value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}