using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represents an event received from the platform.
/// </summary>
[PublicAPI]
public class PlatformEvent
{
    private JsonElement? _data;

    private static readonly JsonSerializerOptions SERIALIZER_OPTIONS;

    /// <summary>
    /// The name of the channel this event was broadcasted on.
    /// </summary>
    public string ChannelName { get; }

    /// <summary>
    /// The deserialized <see cref="Message"/> of this event. Is lazy loaded.
    /// </summary>
    public JsonElement Data
    {
        get
        {
            _data ??= JsonSerializer.Deserialize<JsonElement>(Message, SERIALIZER_OPTIONS);
            return _data.Value;
        }
    }

    /// <summary>
    /// The name of this event.
    /// </summary>
    public string EventName { get; }

    /// <summary>
    /// The serialized message of this event.
    /// </summary>
    /// <seealso cref="Data"/>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlatformEvent"/> class.
    /// </summary>
    /// <param name="eventName">The name of the event.</param>
    /// <param name="channelName">The name of the channel the event was broadcasted on.</param>
    /// <param name="message">The serialized message of the event.</param>
    public PlatformEvent(string eventName, string channelName, string message)
    {
        EventName = eventName;
        ChannelName = channelName;
        Message = message;
    }

    static PlatformEvent()
    {
        SERIALIZER_OPTIONS = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            Converters = { new NullableBigIntegerJsonConverter(), },
        };
    }
}