using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The freezable objects supported on-chain.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum FreezeType
{
    /// <summary>
    /// Represents the <see cref="Collection"/> type.
    /// </summary>
    [EnumMember(Value = "COLLECTION")]
    Collection,

    /// <summary>
    /// Represents the <see cref="CollectionAccount"/> type.
    /// </summary>
    [EnumMember(Value = "COLLECTION_ACCOUNT")]
    CollectionAccount,

    /// <summary>
    /// Represents the <see cref="Token"/> type.
    /// </summary>
    [EnumMember(Value = "TOKEN")]
    Token,

    /// <summary>
    /// Represents the <see cref="TokenAccount"/> type.
    /// </summary>
    [EnumMember(Value = "TOKEN_ACCOUNT")]
    TokenAccount,
}