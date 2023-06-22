using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Represents the claim status of a beam.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum ClaimStatus
{
    /// <summary>
    /// Indicates the claim status is <c>PENDING</c>.
    /// </summary>
    [EnumMember(Value = "PENDING")]
    Pending,

    /// <summary>
    /// Indicates the claim status is <c>IN_PROGRESS</c>.
    /// </summary>
    [EnumMember(Value = "IN_PROGRESS")]
    InProgress,

    /// <summary>
    /// Indicates the claim status is <c>COMPLETED</c>.
    /// </summary>
    [EnumMember(Value = "COMPLETED")]
    Completed,

    /// <summary>
    /// Indicates the claim status is <c>FAILED</c>.
    /// </summary>
    [EnumMember(Value = "FAILED")]
    Failed,
}