using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// The freezable objects supported on-chain.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum ModelType
{
    /// <summary>
    /// Represents the <see cref="Collection"/> type.
    /// </summary>
    [EnumMember(Value = "COLLECTION")]
    Collection
}