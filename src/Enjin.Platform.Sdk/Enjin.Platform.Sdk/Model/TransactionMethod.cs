using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Enum values representing the currently supported transactions.
/// </summary>
/// <seealso cref="Transaction"/>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[PublicAPI]
public enum TransactionMethod
{
    /// <summary>
    /// Indicates the transaction method is <c>ApproveCollection</c>.
    /// </summary>
    [EnumMember(Value = "ApproveCollection")]
    ApproveCollection,

    /// <summary>
    /// Indicates the transaction method is <c>ApproveToken</c>.
    /// </summary>
    [EnumMember(Value = "ApproveToken")]
    ApproveToken,

    /// <summary>
    /// Indicates the transaction method is <c>BatchMint</c>.
    /// </summary>
    [EnumMember(Value = "BatchMint")]
    BatchMint,

    /// <summary>
    /// Indicates the transaction method is <c>BatchSetAttribute</c>.
    /// </summary>
    [EnumMember(Value = "BatchSetAttribute")]
    BatchSetAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>BatchTransfer</c>.
    /// </summary>
    [EnumMember(Value = "BatchTransfer")]
    BatchTransfer,

    /// <summary>
    /// Indicates the transaction method is <c>Burn</c>.
    /// </summary>
    [EnumMember(Value = "Burn")]
    Burn,

    /// <summary>
    /// Indicates the transaction method is <c>CreateCollection</c>.
    /// </summary>
    [EnumMember(Value = "CreateCollection")]
    CreateCollection,

    /// <summary>
    /// Indicates the transaction method is <c>CreateToken</c>.
    /// </summary>
    [EnumMember(Value = "CreateToken")]
    CreateToken,

    /// <summary>
    /// Indicates the transaction method is <c>DestroyCollection</c>.
    /// </summary>
    [EnumMember(Value = "DestroyCollection")]
    DestroyCollection,

    /// <summary>
    /// Indicates the transaction method is <c>Freeze</c>.
    /// </summary>
    [EnumMember(Value = "Freeze")]
    Freeze,

    /// <summary>
    /// Indicates the transaction method is <c>MintToken</c>.
    /// </summary>
    [EnumMember(Value = "MintToken")]
    MintToken,

    /// <summary>
    /// Indicates the transaction method is <c>MutateCollection</c>.
    /// </summary>
    [EnumMember(Value = "MutateCollection")]
    MutateCollection,

    /// <summary>
    /// Indicates the transaction method is <c>MutateToken</c>.
    /// </summary>
    [EnumMember(Value = "MutateToken")]
    MutateToken,

    /// <summary>
    /// Indicates the transaction method is <c>OperatorTransferToken</c>.
    /// </summary>
    [EnumMember(Value = "OperatorTransferToken")]
    OperatorTransferToken,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveAllAttributes</c>.
    /// </summary>
    [EnumMember(Value = "RemoveAllAttributes")]
    RemoveAllAttributes,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveCollectionAttribute</c>.
    /// </summary>
    [EnumMember(Value = "RemoveCollectionAttribute")]
    RemoveCollectionAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveTokenAttribute</c>.
    /// </summary>
    [EnumMember(Value = "RemoveTokenAttribute")]
    RemoveTokenAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>SetCollectionAttribute</c>.
    /// </summary>
    [EnumMember(Value = "SetCollectionAttribute")]
    SetCollectionAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>SetTokenAttribute</c>.
    /// </summary>
    [EnumMember(Value = "SetTokenAttribute")]
    SetTokenAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>SimpleTransferToken</c>.
    /// </summary>
    [EnumMember(Value = "SimpleTransferToken")]
    SimpleTransferToken,

    /// <summary>
    /// Indicates the transaction method is <c>Thaw</c>.
    /// </summary>
    [EnumMember(Value = "Thaw")]
    Thaw,

    /// <summary>
    /// Indicates the transaction method is <c>TransferAllBalance</c>.
    /// </summary>
    [EnumMember(Value = "TransferAllBalance")]
    TransferAllBalance,

    /// <summary>
    /// Indicates the transaction method is <c>TransferBalance</c>.
    /// </summary>
    [EnumMember(Value = "TransferBalance")]
    TransferBalance,

    /// <summary>
    /// Indicates the transaction method is <c>UnapproveCollection</c>.
    /// </summary>
    [EnumMember(Value = "UnapproveCollection")]
    UnapproveCollection,

    /// <summary>
    /// Indicates the transaction method is <c>UnapproveToken</c>.
    /// </summary>
    [EnumMember(Value = "UnapproveToken")]
    UnapproveToken,
}