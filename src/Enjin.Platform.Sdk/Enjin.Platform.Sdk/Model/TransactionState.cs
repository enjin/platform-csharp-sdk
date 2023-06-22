using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the state of a transaction's lifecycle.
/// </summary>
/// <seealso cref="Transaction"/>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TransactionState
{
    /// <summary>
    /// Indicates the transaction state is <c>ABANDONED</c>.
    /// </summary>
    [EnumMember(Value = "ABANDONED")]
    Abandoned,

    /// <summary>
    /// Indicates the transaction state is <c>PENDING</c>.
    /// </summary>
    [EnumMember(Value = "PENDING")]
    Pending,

    /// <summary>
    /// Indicates the transaction state is <c>PROCESSING</c>.
    /// </summary>
    [EnumMember(Value = "PROCESSING")]
    Processing,

    /// <summary>
    /// Indicates the transaction state is <c>BROADCAST</c>.
    /// </summary>
    [EnumMember(Value = "BROADCAST")]
    Broadcast,

    /// <summary>
    /// Indicates the transaction state is <c>EXECUTED</c>.
    /// </summary>
    [EnumMember(Value = "EXECUTED")]
    Executed,

    /// <summary>
    /// Indicates the transaction state is <c>FINALIZED</c>.
    /// </summary>
    [EnumMember(Value = "FINALIZED")]
    Finalized,
}