using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the result status of a transaction.
/// </summary>
/// <seealso cref="Transaction"/>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TransactionResult
{
    /// <summary>
    /// Indicates the transaction result is <c>EXTRINSIC_SUCCESS</c>.
    /// </summary>
    [EnumMember(Value = "EXTRINSIC_SUCCESS")]
    ExtrinsicSuccess,

    /// <summary>
    /// Indicates the transaction result is <c>EXTRINSIC_FAILED</c>.
    /// </summary>
    [EnumMember(Value = "EXTRINSIC_FAILED")]
    ExtrinsicFailed,
}