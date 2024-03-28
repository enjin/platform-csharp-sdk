using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Represents the dispatch call options.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum DispatchCall
{
    /// <summary>
    /// Indicates a dispatch call as <c>MULTI_TOKENS</c>.
    /// </summary>
    [EnumMember(Value = "MULTI_TOKENS")]
    MultiTokens,

    /// <summary>
    /// Indicates a dispatch call as <c>FUEL_TANKS</c>.
    /// </summary>
    [EnumMember(Value = "FUEL_TANKS")]
    FuelTanks,
    
    /// <summary>
    /// Indicates a dispatch call as <c>MARKETPLACE</c>.
    /// </summary>
    [EnumMember(Value = "MARKETPLACE")]
    Marketplace,
}