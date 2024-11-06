using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The freezable objects supported on-chain.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum NetworkType
{
    /// <summary>
    /// Represents the Enjin Relay network.
    /// </summary>
    [EnumMember(Value = "ENJIN_RELAY")]
    EnjinRelay,
    
    /// <summary>
    /// Represents the Enjin Matrix network.
    /// </summary>
    [EnumMember(Value = "ENJIN_MATRIX")]
    EnjinMatrix,
    
    /// <summary>
    /// Represents the Canary Relay network.
    /// </summary>
    [EnumMember(Value = "CANARY_RELAY")]
    CanaryRelay,
    
    /// <summary>
    /// Represents the Canary Matrix network.
    /// </summary>
    [EnumMember(Value = "CANARY_MATRIX")]
    CanaryMatrix,
    
    /// <summary>
    /// Represents the Local Relay network.
    /// </summary>
    [EnumMember(Value = "LOCAL_RELAY")]
    LocalRelay,
    
    /// <summary>
    /// Represents the Local Matrix network.
    /// </summary>
    [EnumMember(Value = "LOCAL_MATRIX")]
    LocalMatrix
}