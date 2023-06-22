using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Represents the marketplace listing state.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum ListingStateEnum
{
    /// <summary>
    /// Indicates the listing state is <c>ACTIVE</c>.
    /// </summary>
    [EnumMember(Value = "ACTIVE")]
    Active,

    /// <summary>
    /// Indicates the listing state is <c>CANCELLED</c>.
    /// </summary>
    [EnumMember(Value = "CANCELLED")]
    Cancelled,

    /// <summary>
    /// Indicates the listing state is <c>FINALIZED</c>.
    /// </summary>
    [EnumMember(Value = "FINALIZED")]
    Finalized,
}