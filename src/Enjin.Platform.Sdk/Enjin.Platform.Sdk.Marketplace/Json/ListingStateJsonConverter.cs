using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// <see cref="JsonConverter"/> for <see cref="ListingState"/> type allowing for the conversion of the <c>ListingData</c>
/// and inheriting types used in the platform's marketplace GraphQL API.
/// </summary>
[PublicAPI]
public class ListingStateJsonConverter : JsonConverter<ListingState>
{
    /// <inheritdoc/>
    /// <remarks>
    /// <para>
    /// <inheritdoc/>
    /// </para>
    /// <para>
    /// If the JSON representing the data is not an object or if the <c>type</c> field is not a string, then the
    /// returned <see cref="ListingState"/> will be returned <c>null</c>.
    /// </para>
    /// </remarks>
    public override ListingState? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            ListingType.Auction => jsonElement.Deserialize<AuctionState>(),
            ListingType.FixedPrice => jsonElement.Deserialize<FixedPriceState>(),
            _ => null
        };
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    /// If the value is not of types <see cref="AuctionState"/> or <see cref="FixedPriceState"/>.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, ListingState value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case AuctionState auctionState:
                writer.WriteRawValue(JsonSerializer.Serialize(auctionState, options));
                break;

            case FixedPriceState fixedPriceState:
                writer.WriteRawValue(JsonSerializer.Serialize(fixedPriceState, options));
                break;

            default:
                throw new ArgumentException($"{nameof(value)} is an unknown type");
        }
    }
}