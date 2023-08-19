﻿using System;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="BigInteger"/> type allowing for the conversion of the unsigned
/// 256-bit <c>BigInt</c> type used in the platform's GraphQL API.
/// </summary>
[UsedImplicitly]
public class BigIntegerJsonConverter : JsonConverter<BigInteger>
{
    /// <inheritdoc/>
    /// <exception cref="FormatException">
    /// If the <see cref="JsonTokenType"/> is not <see cref="JsonTokenType.String"/>.
    /// </exception>
    /// <remarks>
    /// <para>
    /// <inheritdoc/>
    /// </para>
    /// <para>
    /// When returned in a response, the <c>BigInt</c> type on the platform is expected to be returned as a string and
    /// as such this converter only expects string.
    /// </para>
    /// </remarks>
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => BigInteger.Parse(reader.GetString()!, NumberStyles.Integer),
            _ => throw new FormatException($"Invalid {nameof(JsonTokenType)} for {nameof(BigInteger)} field")
        };
    }

    /// <inheritdoc/>
    /// <remarks>
    /// When used as a parameter, the <c>BigInt</c> type on the platform may be passed as a string and as such this
    /// converter writes it as a JSON string.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}