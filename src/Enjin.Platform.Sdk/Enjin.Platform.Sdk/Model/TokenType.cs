using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the quantity setting for a <see cref="Token"/>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TokenType
{
    /// <summary>
    /// Indicates a Fungible token.
    /// </summary>
    [EnumMember(Value = "FUNGIBLE")]
    Fungible,

    /// <summary>
    /// Indicates a Non-Fungible token.
    /// </summary>
    [EnumMember(Value = "NON_FUNGIBLE")]
    NonFungible
}