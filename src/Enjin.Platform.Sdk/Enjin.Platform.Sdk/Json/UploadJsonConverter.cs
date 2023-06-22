using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="Upload"/> type allowing for the conversion of the <c>Upload</c> type used
/// in the platform's GraphQL API.
/// </summary>
[UsedImplicitly]
public class UploadJsonConverter : JsonConverter<Upload>
{
    /// <summary>
    /// Unsupported conversion.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// Always thrown when called.
    /// </exception>
    public override Upload Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotSupportedException($"{nameof(Upload)} is not a valid read type");
    }

    /// <inheritdoc/>
    /// <remarks>
    /// The GraphQL multipart request specification requires uploads to be null in the variables field so that they may
    /// be mapped in HTTP content for the file.
    /// </remarks>
    public override void Write(Utf8JsonWriter writer, Upload value, JsonSerializerOptions options)
    {
        writer.WriteNullValue();
    }
}