using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Represents the dispatch rule options.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum DispatchRuleEnum
{
    /// <summary>
    /// Indicates a dispatch rule as <c>WHITELISTED_CALLERS</c>.
    /// </summary>
    [EnumMember(Value = "WHITELISTED_CALLERS")]
    WhitelistedCallers,

    /// <summary>
    /// Indicates a dispatch rule as <c>WHITELISTED_COLLECTIONS</c>.
    /// </summary>
    [EnumMember(Value = "WHITELISTED_COLLECTIONS")]
    WhitelistedCollections,

    /// <summary>
    /// Indicates a dispatch rule as <c>MAX_FUEL_BURN_PER_TRANSACTION</c>.
    /// </summary>
    [EnumMember(Value = "MAX_FUEL_BURN_PER_TRANSACTION")]
    MaxFuelBurnPerTransaction,

    /// <summary>
    /// Indicates a dispatch rule as <c>USER_FUEL_BUDGET</c>.
    /// </summary>
    [EnumMember(Value = "USER_FUEL_BUDGET")]
    UserFuelBudget,

    /// <summary>
    /// Indicates a dispatch rule as <c>TANK_FUEL_BUDGET</c>.
    /// </summary>
    [EnumMember(Value = "TANK_FUEL_BUDGET")]
    TankFuelBudget,

    /// <summary>
    /// Indicates a dispatch rule as <c>REQUIRE_TOKEN</c>.
    /// </summary>
    [EnumMember(Value = "REQUIRE_TOKEN")]
    RequireToken,
}