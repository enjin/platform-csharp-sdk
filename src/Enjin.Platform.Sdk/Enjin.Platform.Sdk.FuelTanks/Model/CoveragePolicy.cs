using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Enum values representing the fees coverage policy options for a Fuel Tank.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum CoveragePolicy
{
    /// <summary>
    /// Indicates that only Fees will be covered.
    /// </summary>
    [EnumMember(Value = "FEES")]
    SingleMint,

    /// <summary>
    /// Indicates that both Fees and Deposits will be covered.
    /// </summary>
    [EnumMember(Value = "FEES_AND_DEPOSIT")]
    Supply,
}