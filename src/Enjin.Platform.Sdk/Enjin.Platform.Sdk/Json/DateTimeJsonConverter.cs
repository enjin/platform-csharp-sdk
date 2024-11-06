using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="DateTime"/> type allowing for the conversion of the <c>DateTime</c> type
/// used in the platform's GraphQL API.
/// </summary>
[UsedImplicitly]
public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    private static readonly CultureInfo CULTURE_INFO = CultureInfo.InvariantCulture;

    /// <inheritdoc/>
    /// <exception cref="FormatException">
    /// If the <see cref="JsonTokenType"/> is not <see cref="JsonTokenType.String"/>.
    /// </exception>
    /// <remarks>
    /// <para>
    /// <inheritdoc/>
    /// </para>
    /// <para>
    /// When returned in a response, the <c>DateTime</c> type on the platform is expected to be returned as a ISO 8601
    /// string.
    /// </para>
    /// </remarks>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => DateTime.Parse(reader.GetString() ?? throw new FormatException("Null string for DateTime field"), CULTURE_INFO),
            _ => throw new FormatException($"Invalid {nameof(JsonTokenType)} for {nameof(DateTime)} field")
        };
    }

    /// <inheritdoc/>
    /// <remarks>
    /// When used as a parameter, the <c>DateTime</c> type on the platform may be passed as a string and as such this
    /// converter writes it as a JSON string.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("s", CULTURE_INFO));
    }
}