using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Represents the type of a beam.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum BeamType
{
    /// <summary>
    /// Indicates a beam type is <c>TRANSFER_TOKEN</c>.
    /// </summary>
    [EnumMember(Value = "TRANSFER_TOKEN")]
    TransferToken,

    /// <summary>
    /// Indicates a beam type is <c>MINT_ON_DEMAND</c>.
    /// </summary>
    [EnumMember(Value = "MINT_ON_DEMAND")]
    MintOnDemand,
}