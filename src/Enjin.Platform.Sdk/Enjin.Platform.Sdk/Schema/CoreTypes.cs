using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Contains fields describing variable types used in the platform's Core API.
/// </summary>
[PublicAPI]
public static class CoreTypes
{
    // AttributeInput

    /// <summary>
    /// String for <c>AttributeInput</c> type.
    /// </summary>
    public const string AttributeInput = "AttributeInput!";

    /// <summary>
    /// String for an array of <c>AttributeInput</c> type.
    /// </summary>
    public const string AttributeInputArray = "[AttributeInput!]!";

    // BigInt

    /// <summary>
    /// String for <c>BigInt</c> type.
    /// </summary>
    public const string BigInt = "BigInt!";

    /// <summary>
    /// String for an array of <c>BigInt</c> type.
    /// </summary>
    public const string BigIntArray = "[BigInt!]!";

    // Boolean

    /// <summary>
    /// String for <c>Boolean</c> type.
    /// </summary>
    public const string Boolean = "Boolean!";

    /// <summary>
    /// String for an array of <c>Boolean</c> type.
    /// </summary>
    public const string BooleanArray = "[Boolean!]!";

    // BurnParamsInput

    /// <summary>
    /// String for <c>BurnParamsInput</c> type.
    /// </summary>
    public const string BurnParamsInput = "BurnParamsInput!";

    /// <summary>
    /// String for an array of <c>BurnParamsInput</c> type.
    /// </summary>
    public const string BurnParamsInputArray = "[BurnParamsInput!]!";

    // CollectionMutationInput

    /// <summary>
    /// String for <c>CollectionMutationInput</c> type.
    /// </summary>
    public const string CollectionMutationInput = "CollectionMutationInput!";

    /// <summary>
    /// String for an array of <c>CollectionMutationInput</c> type.
    /// </summary>
    public const string CollectionMutationInputArray = "[CollectionMutationInput!]!";

    // CreateTokenParams

    /// <summary>
    /// String for <c>CreateTokenParams</c> type.
    /// </summary>
    public const string CreateTokenParams = "CreateTokenParams!";

    /// <summary>
    /// String for an array of <c>CreateTokenParams</c> type.
    /// </summary>
    public const string CreateTokenParamsArray = "[CreateTokenParams!]!";

    // CryptoSignatureType

    /// <summary>
    /// String for <c>CryptoSignatureType</c> type.
    /// </summary>
    public const string CryptoSignatureType = "CryptoSignatureType!";

    /// <summary>
    /// String for an array of <c>CryptoSignatureType</c> type.
    /// </summary>
    public const string CryptoSignatureTypeArray = "[CryptoSignatureType!]!";

    // DateTime

    /// <summary>
    /// String for <c>DateTime</c> type.
    /// </summary>
    public const string DateTime = "DateTime!";

    /// <summary>
    /// String for an array of <c>DateTime</c> type.
    /// </summary>
    public const string DateTimeArray = "[DateTime!]!";

    // EncodableTokenIdInput

    /// <summary>
    /// String for <c>EncodableTokenIdInput</c> type.
    /// </summary>
    public const string EncodableTokenIdInput = "EncodableTokenIdInput!";

    /// <summary>
    /// String for an array of <c>EncodableTokenIdInput</c> type.
    /// </summary>
    public const string EncodableTokenIdInputArray = "[EncodableTokenIdInput!]!";

    // StringFilterInputType

    /// <summary>
    /// String for <c>StringFilterInput</c> type.
    /// </summary>
    public const string StringFilter = "StringFilter!";
    
    /// <summary>
    /// String for an array of <c>StringFilterInput</c> type.
    /// </summary>
    public const string StringFilterArray = "[StringFilter!]";
    
    // FreezeStateType
    
    /// <summary>
    /// String for <c>FreezeType</c> type.
    /// </summary>
    public const string FreezeState = "FreezeStateType!";

    /// <summary>
    /// String for an array of <c>FreezeType</c> type.
    /// </summary>
    public const string FreezeStateArray = "[FreezeStateType!]!";
    
    // FreezeType

    /// <summary>
    /// String for <c>FreezeType</c> type.
    /// </summary>
    public const string FreezeType = "FreezeType!";

    /// <summary>
    /// String for an array of <c>FreezeType</c> type.
    /// </summary>
    public const string FreezeTypeArray = "[FreezeType!]!";

    // Int

    /// <summary>
    /// String for <c>Int</c> type.
    /// </summary>
    public const string Int = "Int!";

    /// <summary>
    /// String for an array of <c>Int</c> type.
    /// </summary>
    public const string IntArray = "[Int!]!";

    // IntegerRangeString

    /// <summary>
    /// String for <c>IntegerRangeString</c> type.
    /// </summary>
    public const string IntegerRangeString = "IntegerRangeString!";

    /// <summary>
    /// String for an array of <c>IntegerRangeString</c> type.
    /// </summary>
    public const string IntegerRangeStringArray = "[IntegerRangeString!]!";

    // MarketPolicy

    /// <summary>
    /// String for <c>MarketPolicy</c> type.
    /// </summary>
    public const string MarketPolicy = "MarketPolicy!";

    /// <summary>
    /// String for an array of <c>MarketPolicy</c> type.
    /// </summary>
    public const string MarketPolicyArray = "[MarketPolicy!]!";

    // MintPolicy

    /// <summary>
    /// String for <c>MintPolicy</c> type.
    /// </summary>
    public const string MintPolicy = "MintPolicy!";

    /// <summary>
    /// String for an array of <c>MintPolicy</c> type.
    /// </summary>
    public const string MintPolicyArray = "[MintPolicy!]!";

    // MintRecipient

    /// <summary>
    /// String for <c>MintRecipient</c> type.
    /// </summary>
    public const string MintRecipient = "MintRecipient!";

    /// <summary>
    /// String for an array of <c>MintRecipient</c> type.
    /// </summary>
    public const string MintRecipientArray = "[MintRecipient!]!";

    // MintTokenParams

    /// <summary>
    /// String for <c>MintTokenParams</c> type.
    /// </summary>
    public const string MintTokenParams = "MintTokenParams!";

    /// <summary>
    /// String for an array of <c>MintTokenParams</c> type.
    /// </summary>
    public const string MintTokenParamsArray = "[MintTokenParams!]!";

    // MultiTokenIdInput

    /// <summary>
    /// String for <c>MultiTokenIdInput</c> type.
    /// </summary>
    public const string MultiTokenIdInput = "MultiTokenIdInput!";

    /// <summary>
    /// String for an array of <c>MultiTokenIdInput</c> type.
    /// </summary>
    public const string MultiTokenIdInputArray = "[MultiTokenIdInput!]!";

    // OperatorTransferParams

    /// <summary>
    /// String for <c>OperatorTransferParams</c> type.
    /// </summary>
    public const string OperatorTransferParams = "OperatorTransferParams!";

    /// <summary>
    /// String for an array of <c>OperatorTransferParams</c> type.
    /// </summary>
    public const string OperatorTransferParamsArray = "[OperatorTransferParams!]!";

    // SimpleTransferParams

    /// <summary>
    /// String for <c>SimpleTransferParams</c> type.
    /// </summary>
    public const string SimpleTransferParams = "SimpleTransferParams!";

    /// <summary>
    /// String for an array of <c>SimpleTransferParams</c> type.
    /// </summary>
    public const string SimpleTransferParamsArray = "[SimpleTransferParams!]!";

    // String

    /// <summary>
    /// String for <c>String</c> type.
    /// </summary>
    public const string String = "String!";

    /// <summary>
    /// String for an array of <c>String</c> type.
    /// </summary>
    public const string StringArray = "[String!]!";

    // TokenMutationInput

    /// <summary>
    /// String for <c>TokenMutationInput</c> type.
    /// </summary>
    public const string TokenMutationInput = "TokenMutationInput!";

    /// <summary>
    /// String for an array of <c>TokenMutationInput</c> type.
    /// </summary>
    public const string TokenMutationInputArray = "[TokenMutationInput!]!";

    // TransactionMethod

    /// <summary>
    /// String for <c>TransactionMethod</c> type.
    /// </summary>
    public const string TransactionMethod = "TransactionMethod!";

    /// <summary>
    /// String for an array of <c>TransactionMethod</c> type.
    /// </summary>
    public const string TransactionMethodArray = "[TransactionMethod!]!";

    // TransactionResult

    /// <summary>
    /// String for <c>TransactionResult</c> type.
    /// </summary>
    public const string TransactionResult = "TransactionResult!";

    /// <summary>
    /// String for an array of <c>TransactionResult</c> type.
    /// </summary>
    public const string TransactionResultArray = "[TransactionResult!]!";

    // TransactionState

    /// <summary>
    /// String for <c>TransactionState</c> type.
    /// </summary>
    public const string TransactionState = "TransactionState!";

    /// <summary>
    /// String for an array of <c>TransactionState</c> type.
    /// </summary>
    public const string TransactionStateArray = "[TransactionState!]!";

    // TransferRecipient

    /// <summary>
    /// String for <c>TransferRecipient</c> type.
    /// </summary>
    public const string TransferRecipient = "TransferRecipient!";

    /// <summary>
    /// String for an array of <c>TransferRecipient</c> type.
    /// </summary>
    public const string TransferRecipientArray = "[TransferRecipient!]!";

    // ListingStateEnum

    /// <summary>
    /// String for <c>ListingStateEnum</c> type.
    /// </summary>
    public const string ListingStateEnum = "ListingStateEnum!";

    /// <summary>
    /// String for an array of <c>ListingStateEnumArray</c> type.
    /// </summary>
    public const string ListingStateEnumArray = "[ListingStateEnum!]!";
}