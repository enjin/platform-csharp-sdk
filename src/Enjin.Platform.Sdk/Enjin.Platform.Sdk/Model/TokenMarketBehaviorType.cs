using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The freezable objects supported on-chain.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TokenMarketBehaviorType
{
    /// <summary>
    /// Represents Has Royalty.
    /// </summary>
    [EnumMember(Value = "HAS_ROYALTY")]
    HasRoyalty,
    
    /// <summary>
    /// Represents Is Currency.
    /// </summary>
    [EnumMember(Value = "IS_CURRENCY")]
    IsCurrency,
    
    /// <summary>
    /// Represents None.
    /// </summary>
    [EnumMember(Value = "NONE")]
    None
}