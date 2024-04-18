using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the type of filter <see cref="FilterType"/>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum FilterType
{
    /// <summary>
    /// Indicates an AND filter type.
    /// </summary>
    [EnumMember(Value = "AND")]
    And,

    /// <summary>
    /// Indicates an OR filter type.
    /// </summary>
    [EnumMember(Value = "OR")]
    Or,
}