using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The freezable objects supported on-chain.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum FreezeState
{
    /// <summary>
    /// Indicates the token will be permanently frozen.
    /// </summary>
    [EnumMember(Value = "PERMANENT")]
    Permanent,

    /// <summary>
    /// Indicates the token will be frozen temporarily.
    /// </summary>
    [EnumMember(Value = "TEMPORARY")]
    Temporary,

    /// <summary>
    /// Indicates the the token cannot be frozen.
    /// </summary>
    [EnumMember(Value = "NEVER")]
    Never,
}