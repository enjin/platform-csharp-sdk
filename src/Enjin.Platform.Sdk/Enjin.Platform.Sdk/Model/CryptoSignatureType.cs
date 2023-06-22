using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The type of encryption algorithm used to sign messages.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum CryptoSignatureType
{
    /// <summary>
    /// Indicates the ed25519 encryption algorithm.
    /// </summary>
    [EnumMember(Value = "ED25519")]
    Ed25519,

    /// <summary>
    /// Indicates the SR25519 encryption algorithm.
    /// </summary>
    [EnumMember(Value = "SR25519")]
    Sr25519,
}