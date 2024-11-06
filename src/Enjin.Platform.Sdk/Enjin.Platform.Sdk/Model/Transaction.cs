﻿using System;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a blockchain transaction.
/// </summary>
[PublicAPI]
public class Transaction
{
    /// <summary>
    /// The internal ID of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("id")]
    public int? Id { get; private set; }

    /// <summary>
    /// The on-chain ID of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; private set; }

    /// <summary>
    /// The on-chain hash of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("transactionHash")]
    public string? TransactionHash { get; private set; }

    /// <summary>
    /// The on-chain method used for this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("method")]
    public TransactionMethod? Method { get; private set; }

    /// <summary>
    /// The state of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("state")]
    public TransactionState? State { get; private set; }

    /// <summary>
    /// The result of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("result")]
    public TransactionResult? Result { get; private set; }

    /// <summary>
    /// The encoded data of this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("encodedData")]
    public string? EncodedData { get; private set; }
    
    /// <summary>
    /// The encoded signing payload for this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("signingPayload")]
    public string? SigningPayload { get; private set; }
    
    /// <summary>
    /// The decoded signing payload in json format. This is in the correct format to send to wallet connect.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("signingPayloadJson")]
    public JsonElement? SigningPayloadJson { get; private set; }
    
    /// <summary>
    /// The fee paid by this transaction.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("fee")]
    public BigInteger? Fee { get; private set; }
    
    /// <summary>
    /// The deposit made for this transaction.
    /// </summary>
    [JsonConverter(typeof(NullableBigIntegerJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("deposit")]
    public BigInteger? Deposit { get; private set; }

    /// <summary>
    /// The wallet used for signing this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("wallet")]
    public Wallet? Wallet { get; private set; }
    
    /// <summary>
    /// The network used for this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("network")]
    public NetworkType? Network { get; private set; }

    /// <summary>
    /// The idempotency key set for this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("idempotencyKey")]
    public string? IdempotencyKey { get; private set; }
    
    /// <summary>
    /// The block number this transaction was signed at.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("signedAtBlock")]
    public int? SignedAtBlock { get; private set; }

    /// <summary>
    /// The date and time this transaction was created.
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; private set; }
    
    /// <summary>
    /// The date and time this transaction was updated.
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    [JsonInclude]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; private set; }
    
    /// <summary>
    /// The events generated by this transaction.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("events")]
    public Connection<Event>? Events { get; private set; }
}