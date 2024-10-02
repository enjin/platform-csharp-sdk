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
    /// Indicates the transaction method is <c>AcceptCollectionTransfer</c>.
    /// </summary>
    [EnumMember(Value = "AcceptCollectionTransfer")]
    AcceptCollectionTransfer,

    /// <summary>
    /// Indicates the transaction method is <c>AddAccount</c>.
    /// </summary>
    [EnumMember(Value = "AddAccount")]
    AddAccount,

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
    /// Indicates the transaction method is <c>BatchAddAccount</c>.
    /// </summary>
    [EnumMember(Value = "BatchAddAccount")]
    BatchAddAccount,

    /// <summary>
    /// Indicates the transaction method is <c>BatchMint</c>.
    /// </summary>
    [EnumMember(Value = "BatchMint")]
    BatchMint,

    /// <summary>
    /// Indicates the transaction method is <c>BatchRemoveAccount</c>.
    /// </summary>
    [EnumMember(Value = "BatchRemoveAccount")]
    BatchRemoveAccount,

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
    /// Indicates the transaction method is <c>BatchTransferBalance</c>.
    /// </summary>
    [EnumMember(Value = "BatchTransferBalance")]
    BatchTransferBalance,

    /// <summary>
    /// Indicates the transaction method is <c>Burn</c>.
    /// </summary>
    [EnumMember(Value = "Burn")]
    Burn,

    /// <summary>
    /// Indicates the transaction method is <c>CancelListing</c>.
    /// </summary>
    [EnumMember(Value = "CancelListing")]
    CancelListing,

    /// <summary>
    /// Indicates the transaction method is <c>CreateCollection</c>.
    /// </summary>
    [EnumMember(Value = "CreateCollection")]
    CreateCollection,

    /// <summary>
    /// Indicates the transaction method is <c>CreateFuelTank</c>.
    /// </summary>
    [EnumMember(Value = "CreateFuelTank")]
    CreateFuelTank,

    /// <summary>
    /// Indicates the transaction method is <c>CreateListing</c>.
    /// </summary>
    [EnumMember(Value = "CreateListing")]
    CreateListing,

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
    /// Indicates the transaction method is <c>DestroyFuelTank</c>.
    /// </summary>
    [EnumMember(Value = "DestroyFuelTank")]
    DestroyFuelTank,

    /// <summary>
    /// Indicates the transaction method is <c>Dispatch</c>.
    /// </summary>
    [EnumMember(Value = "Dispatch")]
    Dispatch,

    /// <summary>
    /// Indicates the transaction method is <c>DispatchAndTouch</c>.
    /// </summary>
    [EnumMember(Value = "DispatchAndTouch")]
    DispatchAndTouch,

    /// <summary>
    /// Indicates the transaction method is <c>FillListing</c>.
    /// </summary>
    [EnumMember(Value = "FillListing")]
    FillListing,

    /// <summary>
    /// Indicates the transaction method is <c>FinalizeAuction</c>.
    /// </summary>
    [EnumMember(Value = "FinalizeAuction")]
    FinalizeAuction,

    /// <summary>
    /// Indicates the transaction method is <c>Freeze</c>.
    /// </summary>
    [EnumMember(Value = "Freeze")]
    Freeze,

    /// <summary>
    /// Indicates the transaction method is <c>InsertRuleSet</c>.
    /// </summary>
    [EnumMember(Value = "InsertRuleSet")]
    InsertRuleSet,

    /// <summary>
    /// Indicates the transaction method is <c>LimitedTeleportAssets</c>.
    /// </summary>
    [EnumMember(Value = "LimitedTeleportAssets")]
    LimitedTeleportAssets,

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
    /// Indicates the transaction method is <c>MutateFuelTank</c>.
    /// </summary>
    [EnumMember(Value = "MutateFuelTank")]
    MutateFuelTank,

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
    /// Indicates the transaction method is <c>PlaceBid</c>.
    /// </summary>
    [EnumMember(Value = "PlaceBid")]
    PlaceBid,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveAccount</c>.
    /// </summary>
    [EnumMember(Value = "RemoveAccount")]
    RemoveAccount,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveAccountRuleData</c>.
    /// </summary>
    [EnumMember(Value = "RemoveAccountRuleData")]
    RemoveAccountRuleData,

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
    /// Indicates the transaction method is <c>RemoveRuleSet</c>.
    /// </summary>
    [EnumMember(Value = "RemoveRuleSet")]
    RemoveRuleSet,

    /// <summary>
    /// Indicates the transaction method is <c>RemoveTokenAttribute</c>.
    /// </summary>
    [EnumMember(Value = "RemoveTokenAttribute")]
    RemoveTokenAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>ScheduleMutateFreezeState</c>.
    /// </summary>
    [EnumMember(Value = "ScheduleMutateFreezeState")]
    ScheduleMutateFreezeState,

    /// <summary>
    /// Indicates the transaction method is <c>SetCollectionAttribute</c>.
    /// </summary>
    [EnumMember(Value = "SetCollectionAttribute")]
    SetCollectionAttribute,

    /// <summary>
    /// Indicates the transaction method is <c>SetConsumption</c>.
    /// </summary>
    [EnumMember(Value = "SetConsumption")]
    SetConsumption,

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