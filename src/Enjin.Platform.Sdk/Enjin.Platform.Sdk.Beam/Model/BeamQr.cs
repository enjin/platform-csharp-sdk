using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a beam QR.
/// </summary>
[PublicAPI]
public class BeamQr
{
    /// <summary>
    /// The link to the QR image.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("url")]
    public string? Url { get; private set; }

    /// <summary>
    /// The base64 encoded string containing the beam host and code.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("payload")]
    public string? Payload { get; private set; }
}