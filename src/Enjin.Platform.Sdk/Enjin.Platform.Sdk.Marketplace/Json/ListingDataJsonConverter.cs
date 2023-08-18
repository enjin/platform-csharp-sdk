using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="ListingData"/> type allowing for the conversion of the <c>ListingData</c>
/// and inheriting types used in the platform's marketplace GraphQL API.
/// </summary>
/// <seealso cref="ListingData"/>
/// <seealso cref="AuctionData"/>
/// <seealso cref="FixedPriceData"/>
[PublicAPI]
public class ListingDataJsonConverter : JsonConverter<ListingData>
{
    /// <inheritdoc/>
    /// <remarks>
    /// <para>
    /// <inheritdoc/>
    /// </para>
    /// <para>
    /// If the JSON representing the data is not an object or if the <c>type</c> field is not a string, then the
    /// returned <see cref="ListingData"/> will be returned <c>null</c>.
    /// </para>
    /// </remarks>
    public override ListingData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonElement jsonElement = JsonElement.ParseValue(ref reader);

        if (jsonElement.ValueKind != JsonValueKind.Object
         || !jsonElement.TryGetProperty("type", out JsonElement value)
         || value.ValueKind != JsonValueKind.String)
        {
            return null;
        }

        ListingType? type = value.Deserialize<ListingType?>();

        return type switch
        {
            ListingType.Auction => jsonElement.Deserialize<AuctionData>(),
            ListingType.FixedPrice => jsonElement.Deserialize<FixedPriceData>(),
            _ => null
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    /// If the value is not of types <see cref="AuctionData"/> or <see cref="FixedPriceData"/>.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, ListingData value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case AuctionData auctionData:
                writer.WriteRawValue(JsonSerializer.Serialize(auctionData, options));
                break;

            case FixedPriceData fixedPriceData:
                writer.WriteRawValue(JsonSerializer.Serialize(fixedPriceData, options));
                break;

            default:
                throw new ArgumentException($"{nameof(value)} is an unknown type");
        }
    }
}