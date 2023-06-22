using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values the on-chain pallet identifiers.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum PalletIdentifier
{
    /// <summary>
    /// Pallet identifier for marketplace.
    /// </summary>
    [EnumMember(Value = "MARKETPLACE")]
    Marketplace,

    /// <summary>
    /// Pallet identifier for multi-tokens.
    /// </summary>
    [EnumMember(Value = "MULTI_TOKENS")]
    MultiTokens,

    /// <summary>
    /// Pallet identifier for fuel tanks.
    /// </summary>
    [EnumMember(Value = "FUEL_TANKS")]
    FuelTanks,
}