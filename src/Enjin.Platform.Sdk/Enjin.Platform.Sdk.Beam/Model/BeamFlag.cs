using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Represents the flags that may be applied to a beam.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum BeamFlag
{
    /// <summary>
    /// Indicates a beam is flagged as <c>PAUSED</c>.
    /// </summary>
    [EnumMember(Value = "PAUSED")]
    Paused,

    /// <summary>
    /// Indicates a beam is flagged as <c>SINGLE_USE</c>.
    /// </summary>
    [EnumMember(Value = "SINGLE_USE")]
    SingleUse,

    /// <summary>
    /// Indicates a beam is flagged as <c>PRUNABLE</c>.
    /// </summary>
    [EnumMember(Value = "PRUNABLE")]
    Prunable,
}