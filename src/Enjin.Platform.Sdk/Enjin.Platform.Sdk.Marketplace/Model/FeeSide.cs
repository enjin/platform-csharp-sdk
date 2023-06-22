using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Marketplace;

/// <summary>
/// Represents the side of the listing that is considered money and is used to pay fees.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum FeeSide
{
    /// <summary>
    /// Indicates the fee side as <c>NO_FEE</c>.
    /// </summary>
    [EnumMember(Value = "NO_FEE")]
    NoFee,

    /// <summary>
    /// Indicates the fee side as <c>MAKE_FEE</c>.
    /// </summary>
    [EnumMember(Value = "MAKE_FEE")]
    MakeFee,

    /// <summary>
    /// Indicates the fee side as <c>TAKE_FEE</c>.
    /// </summary>
    [EnumMember(Value = "TAKE_FEE")]
    TakeFee,
}