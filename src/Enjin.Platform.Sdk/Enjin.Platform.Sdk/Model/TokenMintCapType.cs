using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the quantity setting for a <see cref="Token"/>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TokenMintCapType
{
    /// <summary>
    /// Indicates that a token can only be minted once, and cannot be re-minted once burned.
    /// </summary>
    [EnumMember(Value = "SINGLE_MINT")]
    SingleMint,

    /// <summary>
    /// Indicates that a limit may be set on the total number of circulating tokens. This type allows for burned tokens
    /// to be re-minted even if the supply amount is 1.
    /// </summary>
    [EnumMember(Value = "SUPPLY")]
    Supply,
    
    /// <summary>
    /// Indicates that there should be no limit on the total number of circulating tokens.
    /// </summary>
    [EnumMember(Value = "INFINITE")]
    Infinite,
}