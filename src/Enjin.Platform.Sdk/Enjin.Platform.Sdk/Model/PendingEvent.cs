using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Enjin.Platform.Sdk.PendingEvents;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a collection on the platform.
/// </summary>
/// <remarks>
/// A collection groups together tokens and sets the policies that apply to them.
/// </remarks>
[PublicAPI]
public class PendingEvent
{
    /// <summary>
    /// The ID assigned to this pending event.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("id")]
    public BigInteger? Id { get; private set; }

    /// <summary>
    /// The uuid assigned to this pending event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("uuid")]
    public string? Uuid { get; private set; }

    /// <summary>
    /// The name of the event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// When this event was sent.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("sent")]
    public string? Sent { get; private set; }
    
    /// <summary>
    /// The blockchain network.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("network")]
    public string? Network { get; private set; }

    /// <summary>
    /// The channels this event was sent to.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("channels")]
    public IEnumerable<string>? Channels { get; private set; }

    /// <summary>
    /// The data payload for this event.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("data")]
    public JsonElement? Data { get; private set; }
    
    public PendingEventDataBase? DataTyped
    {
        get
        {
            if (Name == null || Data == null)
            {
                return null;
            }

            switch (Name)
            {
                case "platform:transfer":
                {
                    return JsonSerializer.Deserialize<PendingEventDataTransfer>(Data.Value.GetRawText());
                }
                case "platform:token-transferred":
                {
                    return JsonSerializer.Deserialize<PendingEventDataTokenTransferred>(Data.Value.GetRawText());
                }
                case "platform:reserved":
                {
                    return JsonSerializer.Deserialize<PendingEventDataReserved>(Data.Value.GetRawText());
                }
                case "platform:withdraw":
                {
                    return JsonSerializer.Deserialize<PendingEventDataWithdraw>(Data.Value.GetRawText());
                }
                case "platform:deposit":
                {
                    return JsonSerializer.Deserialize<PendingEventDataDeposit>(Data.Value.GetRawText());
                }
                case "platform:token-minted":
                {
                    return JsonSerializer.Deserialize<PendingEventDataTokenMinted>(Data.Value.GetRawText());
                }
                case "platform:token-created":
                {
                    return JsonSerializer.Deserialize<PendingEventDataTokenCreated>(Data.Value.GetRawText());
                }
                case "platform:collection-created":
                {
                    return JsonSerializer.Deserialize<PendingEventDataCollectionCreated>(Data.Value.GetRawText());
                }
            }

            // Unsupported
            return null;
        }
    }
}